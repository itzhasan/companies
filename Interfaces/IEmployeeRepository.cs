using Company.Dtos.Employee;
using Company.Models;

namespace Company.Interfaces;
public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> CreateAsync(Employee employeeModel);
    Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employDto);
    Task<Employee?> DeleteAsync(int id);
}