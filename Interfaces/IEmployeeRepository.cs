using Company.Contracts;
using Company.Dtos.Company;
using Company.Dtos.Employee;
using Company.Models;

namespace Company.Interfaces;

public interface IEmployeeRepository
{
    Task<PaginatedResponse<Employee>> GetAllAsync(CompanyQueryDto companyQueryDto);
    Task<Employee?> GetByIdAsync(int id);
    Task<List<Employee>> GetByDepartmentId(int id);
    Task<Employee> CreateAsync(Employee employeeModel);
    Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employDto);
    Task<Employee?> DeleteAsync(int id);
}