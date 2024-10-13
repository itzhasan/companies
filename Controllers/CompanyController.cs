using Company.Dtos.Company;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController(ICompanyRepository companyRepository) : ControllerBase
{
    private readonly ICompanyRepository _companyRepo = companyRepository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var company = await _companyRepo.GetAllAsync();
        var companyDto = company.Select(s => s.ToCompanyDto());
        return Ok(company);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var company = await _companyRepo.GetByIdAsync(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company.ToCompanyDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDto companyDto)
    {
        var companyModel = companyDto.ToDepartmentFormCreateDTO();
        await _companyRepo.CreateAsync(companyModel);
        return CreatedAtAction(nameof(GetById), new { id = companyModel.Id }, companyModel.ToCompanyDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyRequestDto updateDto)
    {
        var companyModel = await _companyRepo.UpdateAsync(id, updateDto);
        if (companyModel == null)
        {
            return NotFound();
        }
        return Ok(companyModel.ToCompanyDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var companyModel = await _companyRepo.DeleteAsync(id);
        if (companyModel == null)
        {
            return NotFound();
        }
        return Ok("deleted");
    }
}