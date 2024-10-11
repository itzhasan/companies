using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Employ;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/employ")]
    [ApiController]
    public class EmployController(IEmployRepository employRepo ,IDepartmentRepository departmentRepo) : ControllerBase
    {
        private readonly IEmployRepository _employRepo = employRepo;
        private readonly IDepartmentRepository _departmentRepo = departmentRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employs = await _employRepo.GetAllAsync();
            var employDto = employs.Select(s => s.ToEmployDto());
            return Ok(employs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var employ = await _employRepo.GetByIdAsync(id);
            if (employ == null)
            {
                return NotFound();
            }
            return Ok(employ.ToEmployDto());
        }

        [HttpPost("{departmentId}")]
        public async Task<IActionResult> Create([FromRoute] int departmentId, CreateEmployRequestDto employDto)
        {
            if(!await _departmentRepo.DepartmentExists(departmentId)){
                return BadRequest("department not exist");
            }
            var employModel = employDto.ToEmployFormCreateDTO(departmentId);
            await _employRepo.CreateAsync(employModel);
            return CreatedAtAction(nameof(GetById), new { id = employModel.Id }, employModel.ToEmployDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateEmployRequestDto updateDto){
            var employModel = await _employRepo.UpdateAsync(id , updateDto);
            if(employModel == null){
                return NotFound();
            }
            return Ok(employModel.ToEmployDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var employModel = await _employRepo.DeleteAsync(id);
            if(employModel == null){
                return NotFound();
            }
            return Ok("deleted");
        }
    }
}