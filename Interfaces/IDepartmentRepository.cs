using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Department;
using Company.Models;

namespace Company.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department departmentModel);
        Task<Department?> UpdateAsync(int id, UpdateDepartmentRequestDto departmentDto);
        Task<Department?> DeleteAsync(int id);
    }
}