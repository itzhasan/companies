using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;
using Company.Dtos.Department;
using Company.Interfaces;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository
{
    public class DepartmentRepository(ApplicationDBContext context) : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Department> CreateAsync(Department departmentModel)
        {
            await _context.Departments.AddAsync(departmentModel);
            await _context.SaveChangesAsync();
            return departmentModel;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var departmentModel = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (departmentModel == null)
            {
                return null;
            }
            _context.Departments.Remove(departmentModel);
            await _context.SaveChangesAsync();
            return departmentModel;
        }

        public Task<bool> DepartmentExists(int id)
        {
            return _context.Departments.AnyAsync(s => s.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Department?> UpdateAsync(int id, UpdateDepartmentRequestDto departmentDto)
        {
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDepartment == null)
            {
                return null;
            }
            existingDepartment.Name = departmentDto.Name;
            existingDepartment.Type = departmentDto.Type;

            await _context.SaveChangesAsync();
            return existingDepartment;
        }
    }
}