﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using paysky_task.Dataidentity;
using paysky_task.DTOs;
using paysky_task.Models;
using paysky_task.Services;

namespace paysky_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IemployeService _employeService;
       
        public EmployeesController(IemployeService employeService)
        {
            _employeService = employeService;
           
        }


        // post
        [HttpPost("Create")]
        public async Task<IActionResult> ADDED(EmployeesDTO DTO)
        {
            
            
                if(ModelState.IsValid == true)
                {
                var emp = new Employee() { UserName = DTO.UserName , City = DTO.City , Salary = DTO.Salary};
                await _employeService.add(emp);
                return Ok(emp);
                }
                else
                {
                    return BadRequest("something is wrong");
                }
            

        }
        // get all 
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
         var items =  await _employeService.GetAll();
            return Ok(items);
        }
        // get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> getitembyid(int id)
        {
           var item =  await _employeService.getbyid(id);
            return Ok(item);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _employeService.getbyid(id);
            if (item == null)
                return NotFound("not found");
            _employeService.Delete(item);
            return Ok(item);
        }
        // update
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromForm]int id , EmployeesDTO DTO)
        {
            var item1 = _employeService.getbyid(id);
            if (item1 == null)
            {
                return NotFound("no employee fount");
            }
            else
            {
                return Ok();
            }
        }





       











    }
}
