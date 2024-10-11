using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;
using Company.Dtos.Employ;
using Company.Interfaces;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository
{
    public class EmployRepository(ApplicationDBContext context) : IEmployRepository
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<Employ> CreateAsync(Employ employModel)
        {
            await _context.Employs.AddAsync(employModel);
            await _context.SaveChangesAsync();
            return employModel;
        }

        public async Task<Employ?> DeleteAsync(int id)
        {
             var employModel = await _context.Employs.FirstOrDefaultAsync(x => x.Id == id);
            if (employModel == null)
            {
                return null;
            }
            _context.Employs.Remove(employModel);
            await _context.SaveChangesAsync();
            return employModel;
        }

        public async Task<List<Employ>> GetAllAsync()
        {
            return await _context.Employs.ToListAsync();
        }

        public async Task<Employ?> GetByIdAsync(int id)
        {
            return await _context.Employs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Employ?> UpdateAsync(int id, UpdateEmployRequestDto employDto)
        {
            var existingEmploy = await _context.Employs.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmploy == null)
            {
                return null;
            }
            existingEmploy.Name = employDto.Name;
            existingEmploy.Age = employDto.Age;

            await _context.SaveChangesAsync();
            return existingEmploy;
        }
    }
}