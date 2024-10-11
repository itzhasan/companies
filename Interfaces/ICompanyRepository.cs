using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Company;

namespace Company.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company.Models.Company>> GetAllAsync();
        Task<Company.Models.Company?> GetByIdAsync(int id);
        Task<Company.Models.Company> CreateAsync(Company.Models.Company companyModel);
        Task<Company.Models.Company?> UpdateAsync(int id, UpdateCompanyRequestDto companyDto);
        Task<Company.Models.Company?> DeleteAsync(int id);
        Task<bool> CompanyExists(int id);
    }
}