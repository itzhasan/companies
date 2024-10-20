using Company.Contracts;
using Company.Data;
using Company.Dtos.Company;
using Company.Dtos.Department;
using Company.Helpers;
using Company.Interfaces;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository;
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

    public async Task<PaginatedResponse<Department>> GetAllAsync(CompanyQueryDto queryDto)
    {
        IQueryable<Department> query = _context.Departments.Include(c => c.Employees);

        return await PaginatedResponse<Department>.CreateAsync(query, queryDto.CurrentPage, queryDto.PageSize);
    }

    public async Task<List<Department>> GetByCompanyId(int id)
    {
        return await _context.Departments
            .Include(c => c.Employees)
            .Where(d => d.CompanyId == id)
            .ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments.Include(c => c.Employees).FirstOrDefaultAsync(i => i.Id == id);
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
