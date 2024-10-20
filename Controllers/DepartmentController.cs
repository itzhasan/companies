using Company.Dtos.Department;
using Company.Dtos.TransferDepartmentDto;
using Company.Helpers;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers;
[Route("api/department")]
[ApiController]
public class DepartmentController(IDepartmentRepository departmentRepo, ICompanyRepository companyRepo, ITransferDepartmentService transferDepartment) : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepo = departmentRepo;
    private readonly ICompanyRepository _companyRepo = companyRepo;
    private readonly ITransferDepartmentService _transfer = transferDepartment;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        var department = await _departmentRepo.GetAllAsync(query);
        var departmentDto = department.Select(s => s.ToDepartmentDto());
        return Ok(departmentDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var department = await _departmentRepo.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department.ToDepartmentDto());
    }

    [HttpGet("company/{companyId:int}")]
    public async Task<IActionResult> GetByCompanyId([FromRoute] int companyId)
    {
        if (!await _companyRepo.CompanyExists(companyId))
        {
            return BadRequest("company not exist");
        }
        var departments = await _departmentRepo.GetByCompanyId(companyId);
        if (departments == null)
        {
            return NotFound();
        }
        var departmentDto = departments.Select(s => s.ToDepartmentDto());
        return Ok(departmentDto);
    }


    [HttpPost("{companyId:int}")]
    public async Task<IActionResult> Create([FromRoute] int companyId, CreateDepartmentRequestDto departmentDto)
    {
        if (!await _companyRepo.CompanyExists(companyId))
        {
            return BadRequest("company not exist");
        }
        var departmentModel = departmentDto.ToDepartmentFormCreateDTO(companyId);
        await _departmentRepo.CreateAsync(departmentModel);
        return CreatedAtAction(nameof(GetById), new { id = departmentModel.Id }, departmentModel.ToDepartmentDto());
        //return Ok("ok");
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDepartmentRequestDto updateDto)
    {
        var departmentModel = await _departmentRepo.UpdateAsync(id, updateDto);
        if (departmentModel == null)
        {
            return NotFound();
        }
        return Ok(departmentModel.ToDepartmentDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var departmentModel = await _departmentRepo.DeleteAsync(id);
        if (departmentModel == null)
        {
            return NotFound();
        }
        return Ok("deleted");
    }

    [HttpPost]
    [Route("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferDepartmentDto transferDepartmentDto)
    {
        await _transfer.MoveDepartmentToAnotherCompanyAsync(transferDepartmentDto);
        return Ok("ok");
    }
}
