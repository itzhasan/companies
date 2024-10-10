using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Department;
using Company.Interfaces;
using Company.Models;

namespace Company.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<Department> CreateAsync(Department departmentModel)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> UpdateAsync(int id, UpdateDepartmentRequestDto departmentDto)
        {
            throw new NotImplementedException();
        }
    }
}