using Company.Dtos.Employ;
using Company.Dtos.TransfereEmployDto;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController(IEmployRepository employRepo, IDepartmentRepository departmentRepo, ITransfereEmployService transfereEmployService) : ControllerBase
{
    private readonly IEmployRepository _employRepo = employRepo;
    private readonly IDepartmentRepository _departmentRepo = departmentRepo;
    private readonly ITransfereEmployService _transfereEmployService = transfereEmployService;

    [HttpGet]
    public async Task<IActionResult> GetAll()//add paginating
    {
        var employs = await _employRepo.GetAllAsync();
        var employDto = employs.Select(s => s.ToEmployDto());
        return Ok(employs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employ = await _employRepo.GetByIdAsync(id);
        if (employ == null) // error handling
        {
            return NotFound();
        }
        return Ok(employ.ToEmployDto());
    }

    [HttpPost("{departmentId:int}")]
    public async Task<IActionResult> Create(int departmentId, CreateEmployRequestDto employDto)
    {
        if (!await _departmentRepo.DepartmentExists(departmentId))
        {
            return BadRequest("department not exist");
        }
        var employModel = employDto.ToEmployFormCreateDTO(departmentId);
        await _employRepo.CreateAsync(employModel);
        return CreatedAtAction(nameof(GetById), new { id = employModel.Id }, employModel.ToEmployDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployRequestDto updateDto)
    {
        var employModel = await _employRepo.UpdateAsync(id, updateDto);
        if (employModel == null)
        {
            return NotFound();
        }
        return Ok(employModel.ToEmployDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employModel = await _employRepo.DeleteAsync(id);
        if (employModel == null)
        {
            return NotFound();
        }
        return Ok("deleted");
    }
    [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> Transfere([FromBody] TransferEmployDto transferEmployDto)
        {
            await _transfereEmployService.MoveEmployToAnotherDepartmentAsync(transferEmployDto);
            return Ok("ok");
        }
}