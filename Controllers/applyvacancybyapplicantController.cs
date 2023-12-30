using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paysky_task.DTOs;
using paysky_task.Models;

namespace paysky_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class applyvacancybyapplicantController : ControllerBase
    {
        private readonly customcontext context;

        public applyvacancybyapplicantController(customcontext context)
        {
            this.context = context;
        }

        // searching to vacancy by title or discreption 
        [HttpGet("message")]
        public IActionResult searching(string message)
        {
            var vacancy = context.vacancies.Where(s => s.Title.Contains(message) || s.Description.Contains(message)).ToList();
            if (vacancy == null)
            {
                return BadRequest("sorry not found");
            }
           
            return Ok(vacancy);
        }

        // applicant apply avilable vacancy have 2 constrain [applicants <= maxapplicant] - [after one day per expiredate]

        [HttpGet("apply")]
        public IActionResult applyvacancy(applyvacancyDTO aplcdto)
        {
            // this vacancy == vacancyid i have it from client
            //var vacancy = context.vacancies.Include(s => s.applicants).FirstOrDefault(s => s.Id == aplcdto.vacancyid);
            //if (vacancy == null)
            //{
            //    return BadRequest("Not found");
            //}
            //// 2 constrain
            //// allowing maxcount
            //if(vacancy.applicants.Count() >= vacancy.MaxApplications)
            //{
            //    return BadRequest("sorry not allow");
            //}
            //// after per 24h
            //if(vacancy.applicants.)


           var vacancy = context.vacancies.Include(s => s.applicants).FirstOrDefault(s => s.Id == aplcdto.vacancyid);

            if (vacancy == null)
            {
                return BadRequest("not found");
            }
            if(vacancy.applicants.Count() > vacancy.MaxApplications)
            {
                return BadRequest("sorry not allow");
            }
            if(aplcdto.startdate < DateTime.Now.AddHours(24))
            {
                return BadRequest("sorry not allow must after 24 hours");
            }
            Applicant apc = new Applicant() 
            {
            Name = aplcdto.Name,
            startdate = aplcdto.startdate,
            vacancyid = aplcdto.vacancyid,
            
            
            };
            context.applicants.Add(apc);
            context.SaveChanges();


            return Ok(apc);
        }








    }
}
