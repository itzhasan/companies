using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Employ;
using Company.Models;

namespace Company.Interfaces
{
    public interface IEmployRepository
    {
        Task<List<Employ>> GetAllAsync();
        Task<Employ?> GetByIdAsync(int id);
        Task<Employ> CreateAsync(Employ employModel);
        Task<Employ?> UpdateAsync(int id, UpdateEmployRequestDto employDto);
        Task<Employ?> DeleteAsync(int id);
    }
}