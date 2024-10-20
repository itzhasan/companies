using Company.Data;
using Company.Dtos.Employee;
using Company.Helpers;
using Company.Interfaces;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository;
public class EmployeeRepository(ApplicationDBContext context) : IEmployeeRepository
{
    private readonly ApplicationDBContext _context = context;
    public async Task<Employee> CreateAsync(Employee employModel)
    {
        await _context.Employees.AddAsync(employModel);
        await _context.SaveChangesAsync();
        return employModel;
    }

    public async Task<Employee?> DeleteAsync(int id)
    {
        var employModel = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (employModel == null)
        {
            return null;
        }
        _context.Employees.Remove(employModel);
        await _context.SaveChangesAsync();
        return employModel;
    }

    public async Task<List<Employee>> GetAllAsync(QueryObject query)
    {
        var skipNumber = (query.PageNumber - 1) * query.PageSize;
        return await _context.Employees.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<List<Employee>> GetByDepartmentId(int id)
    {
        return await _context.Employees
            .Where(d => d.DepartmentId == id)
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto)
    {
        var existingEmploy = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (existingEmploy == null)
        {
            return null;
        }
        existingEmploy.Name = employeeDto.Name;
        existingEmploy.Age = employeeDto.Age;

        await _context.SaveChangesAsync();
        return existingEmploy;
    }
}
