using Company.Contracts;
using Company.Dtos.Company;
using Company.Helpers;

namespace Company.Interfaces;
public interface ICompanyRepository
{
    Task<PaginatedResponse<Company.Models.Company>> GetAllAsync(CompanyQueryDto companyQueryDto);
    Task<Company.Models.Company?> GetByIdAsync(int id);
    Task<Company.Models.Company> CreateAsync(Company.Models.Company companyModel);
    Task<Company.Models.Company?> UpdateAsync(int id, UpdateCompanyRequestDto companyDto);
    Task<Company.Models.Company?> DeleteAsync(int id);
    Task<bool> CompanyExists(int id);
}