using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;
using Company.Dtos.Company;
using Company.Interfaces;
using Company.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepo;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepo = companyRepository;
    }

    [HttpGet]
public async Task<IActionResult> GetAll(){
    var companies = await _companyRepo.GetAllAsync();
    var companyDtos = companies.Select(c => c.ToCompanyDto());
    return Ok(companyDtos);
}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var company = await _companyRepo.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company.ToCompanyDto());
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDto companyDto)
    {
        try
        {
            var companyModel = companyDto.ToStockFormCreateDTO();
            await _companyRepo.CreateAsync(companyModel);
            return CreatedAtAction(nameof(GetById), new { id = companyModel.Id }, companyModel.ToCompanyDto());
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    private IActionResult HandleException(Exception ex)
    {
        var errorDetails = new
        {
            Message = ex.Message,
            StackTrace = ex.StackTrace
        };

        return BadRequest(errorDetails);
    }
}

}