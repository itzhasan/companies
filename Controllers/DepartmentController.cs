using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Department;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController(IDepartmentRepository departmentRepo ,ICompanyRepository companyRepo) : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepo = departmentRepo;
        private readonly ICompanyRepository _companyRepo = companyRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var department = await _departmentRepo.GetAllAsync();
            var departmentDto = department.Select(s => s.ToDepartmentDto());
            return Ok(departmentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department.ToDepartmentDto());
        }

        [HttpPost("{companyId}")]
        public async Task<IActionResult> Create([FromRoute] int companyId, CreateDepartmentRequestDto departmentDto)
        {
            if(!await _companyRepo.CompanyExists(companyId)){
                return BadRequest("company not exist");
            }
            var departmentModel = departmentDto.ToDepartmentFormCreateDTO(companyId);
            await _departmentRepo.CreateAsync(departmentModel);
            return CreatedAtAction(nameof(GetById), new { id = departmentModel.Id }, departmentModel.ToDepartmentDto());
            //return Ok("ok");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateDepartmentRequestDto updateDto){
            var departmentModel = await _departmentRepo.UpdateAsync(id , updateDto);
            if(departmentModel == null){
                return NotFound();
            }
            return Ok(departmentModel.ToDepartmentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var departmentModel = await _departmentRepo.DeleteAsync(id);
            if(departmentModel == null){
                return NotFound();
            }
            return Ok("deleted");
        }
    }
}