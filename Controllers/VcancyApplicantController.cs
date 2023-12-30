using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paysky_task.DTOs;
using paysky_task.Models;
using paysky_task.Services;
using System;

namespace paysky_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VcancyApplicantController : ControllerBase
    {
        private readonly IVacancyService vacancyService;
        private readonly customcontext context;
        public VcancyApplicantController(IVacancyService vacancyService, customcontext context)
        {
            this.vacancyService = vacancyService;
            this.context = context;
        }
       
        // create a vacancy
        [HttpPost("Create")]
        public async Task<IActionResult> Create(VacancyDTO VCNDTO)
        {
           // DateTime item = VCNDTO.ExpireDae;
            
                if (ModelState.IsValid)
                {
                try
                {

                    var vacancy = new Vacancy()
                    {
                        Title = VCNDTO.Title,
                        Description = VCNDTO.Description,
                        ExpireDae = VCNDTO.ExpireDae,
                        MaxApplications = VCNDTO.MaxApplications,
                        IsActive = true,

                    };

                    await vacancyService.Create(vacancy);
                    return Ok(vacancy);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        Message = "write this format : yyyy-MM-ddTHH:mm:ss",
                        ErrorDetails = ex.Message
                    });
                }
                }
            
           
            return Ok();







        }
        // for update a vacancy
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , VacancyDTO VCNDTO)
        {
            
           if (!ModelState.IsValid)
            {
                return BadRequest("ERROR");
            }
           else
            {
               var item = context.vacancies.FirstOrDefault(s => s.Id == id);
                if (item == null)
                    return NotFound("Not found");
                item.Title = VCNDTO.Title;
                item.Description = VCNDTO.Description;
                item.MaxApplications = VCNDTO.MaxApplications;
                item.ExpireDae = VCNDTO.ExpireDae;
                context.vacancies.Update(item);
                context.SaveChanges();
                return Ok(item);
            }

        }

        //  Deactivate a vacancy
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var vacancy = await vacancyService.getbyid(id);
            if(vacancy == null)
            {
                return NotFound("sorry is not found");
            }
            if(vacancy.IsActive == false)
            {
                return NotFound("this is vacancy is aready not active");
            }
            vacancyService.DeactivateVacancy(vacancy);
            return Ok(vacancy);

        }

        // get all applicants of vacancy
        [HttpGet("{id}")]
        public async Task<IActionResult> GettALLapplicants(int id)
        {
           var vacancy = context.vacancies.Include(s => s.applicants).FirstOrDefault(s => s.Id == id);
            if(vacancy == null) { return NotFound("sorry not found"); }
            // mapping it by DTO or aonymous obj 
            var applicants = vacancy.applicants.Select(s => new  {  Name = s.Name}).ToList();

           
          //  var applicants = vacancy.applicants.ToList();
            return Ok(applicants);

        }

        // to Delete vacancy
        // 
        [HttpDelete("{id}")]
         public async Task<IActionResult> Remove(int id)
        {
            var vacancy = await vacancyService.getbyid(id);
            if (vacancy == null)
            {
                return NotFound("sorry is not found");
            }
            vacancyService.Delete(vacancy);
            return Ok(vacancy);
        }


    }
}
