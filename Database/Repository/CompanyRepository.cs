using Company.Contracts;
using Company.Data;
using Company.Dtos.Company;
using Company.Helpers;
using Company.Interfaces;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository;

public class CompanyRepository(ApplicationDBContext applicationDBContext) : ICompanyRepository
{
    private readonly ApplicationDBContext _context = applicationDBContext;

    public async Task<Models.Company> CreateAsync(Models.Company companyModel)
    {
        await _context.Companies.AddAsync(companyModel);
        await _context.SaveChangesAsync();
        return companyModel;
    }

    public async Task<Company.Models.Company?> DeleteAsync(int id)
    {
        var companyModel = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (companyModel == null)
        {
            return null;
        }
        _context.Companies.Remove(companyModel);
        await _context.SaveChangesAsync();
        return companyModel;
    }

    public async Task<PaginatedResponse<Models.Company>> GetAllAsync(CompanyQueryDto companyQueryDto)
    {
        IQueryable<Company.Models.Company> query = _context.Companies.Include(c => c.Departments);

        return await PaginatedResponse<Models.Company>.CreateAsync(query, companyQueryDto.CurrentPage, companyQueryDto.PageSize);
    }


    public async Task<Models.Company?> GetByIdAsync(int id)
    {
        return await _context.Companies.Include(c => c.Departments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<bool> CompanyExists(int id)
    {
        return await _context.Companies.AnyAsync(s => s.Id == id);
    }

    public async Task<Models.Company?> UpdateAsync(int id, UpdateCompanyRequestDto companyDto)
    {
        var existingCompany = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCompany == null)
        {
            return null;
        }
        existingCompany.Name = companyDto.Name;
        existingCompany.Type = companyDto.Type;

        await _context.SaveChangesAsync();
        return existingCompany;
    }
}
