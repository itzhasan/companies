using Company.Dtos.Employee;
using Company.Dtos.TransferEmployDto;
using Company.Helpers;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController(IEmployeeRepository employeeRepo, IDepartmentRepository departmentRepo, ITransferEmployeeService transferEmployService) : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepo = employeeRepo;
    private readonly IDepartmentRepository _departmentRepo = departmentRepo;
    private readonly ITransferEmployeeService _transferEmployeeService = transferEmployService;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)//add paginating
    {
        var employs = await _employeeRepo.GetAllAsync(query);
        var employDto = employs.Select(s => s.ToEmployeeDto());
        return Ok(employs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _employeeRepo.GetByIdAsync(id);
        if (employee == null) // error handling
        {
            return NotFound();
        }
        return Ok(employee.ToEmployeeDto());
    }

    [HttpGet("department/{departmentId:int}")]
    public async Task<IActionResult> GetByCompanyId([FromRoute] int departmentId)
    {
        if (!await _departmentRepo.DepartmentExists(departmentId))
        {
            return BadRequest("department not exist");
        }
        var employees = await _employeeRepo.GetByDepartmentId(departmentId);
        if (employees == null)
        {
            return NotFound();
        }
        var departmentDto = employees.Select(s => s.ToEmployeeDto());
        return Ok(departmentDto);
    }
    
    [HttpPost("{departmentId:int}")]
    public async Task<IActionResult> Create(int departmentId, CreateEmployeeRequestDto employeeDto)
    {
        if (!await _departmentRepo.DepartmentExists(departmentId))
        {
            return BadRequest("department not exist");
        }
        var employModel = employeeDto.ToEmployeeFormCreateDTO(departmentId);
        await _employeeRepo.CreateAsync(employModel);
        return CreatedAtAction(nameof(GetById), new { id = employModel.Id }, employModel.ToEmployeeDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployeeRequestDto updateDto)
    {
        var employModel = await _employeeRepo.UpdateAsync(id, updateDto);
        if (employModel == null)
        {
            return NotFound();
        }
        return Ok(employModel.ToEmployeeDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employModel = await _employeeRepo.DeleteAsync(id);
        if (employModel == null)
        {
            return NotFound();
        }
        return Ok("deleted");
    }
    [HttpPost]
    [Route("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferEmployeeDto transferEmployeeDto)
    {
        await _transferEmployeeService.MoveEmployeeToAnotherDepartmentAsync(transferEmployeeDto);
        return Ok("ok");
    }
}