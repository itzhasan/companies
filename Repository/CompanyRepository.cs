using Company.Data;
using Company.Dtos.Company;
using Company.Interfaces;
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

    public async Task<Models.Company?> DeleteAsync(int id)
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

    public async Task<List<Models.Company>> GetAllAsync()
    {
        return await _context.Companies.Include(c => c.Departments).ToListAsync();
    }

    public async Task<Models.Company?> GetByIdAsync(int id)
    {
        return await _context.Companies.Include(c => c.Departments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> CompanyExists(int id)
    {
        return _context.Companies.AnyAsync(s => s.Id == id);
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
