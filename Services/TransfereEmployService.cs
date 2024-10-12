using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;
using Company.Dtos.TransfereEmployDto;
using Company.Interfaces;

namespace Company.Services
{
    public class TransfereEmployService(ApplicationDBContext context) : ITransfereEmployService
    {
        private readonly ApplicationDBContext _context = context;
        public async Task MoveEmployToAnotherDepartmentAsync(TransferEmployDto transferEmployDto)
        {
             var employ = await _context.Employs.FindAsync(transferEmployDto.EmployId);
            if (employ == null)
            {
                throw new ArgumentException($"Employ with Id {transferEmployDto.EmployId} not found.");
            }

            var department = await _context.Departments.FindAsync(transferEmployDto.DepartmentId);
            if (department == null)
            {
                throw new ArgumentException($"Department with Id {transferEmployDto.DepartmentId} not found.");
            }

            var targetDepartment = await _context.Departments.FindAsync(transferEmployDto.TargetDepartmentId);
            if (targetDepartment == null)
            {
                throw new ArgumentException($"Target Department with Id {transferEmployDto.TargetDepartmentId} not found.");
            }

            department.Employs.Remove(employ);

            targetDepartment.Employs.Add(employ);

            await _context.SaveChangesAsync();
        }
    }
}