using Company.Contracts;
using Company.Dtos.Company;
using Company.Dtos.Department;
using Company.Models;

namespace Company.Interfaces;

public interface IDepartmentRepository
{
    Task<PaginatedResponse<Department>> GetAllAsync(CompanyQueryDto companyQueryDto);
    Task<Department?> GetByIdAsync(int id);
    Task<List<Department>> GetByCompanyId(int id);
    Task<Department> CreateAsync(Department departmentModel);
    Task<Department?> UpdateAsync(int id, UpdateDepartmentRequestDto departmentDto);
    Task<Department?> DeleteAsync(int id);
    Task<bool> DepartmentExists(int id);
}
