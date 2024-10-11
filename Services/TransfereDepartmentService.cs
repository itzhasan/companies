using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;
using Company.Dtos.TansfereDepartmentDto;
using Company.Interfaces;

namespace Company.Services
{
    public class TransfereDepartmentService(ApplicationDBContext context) : ITransfereDepartmentService
    {
        private readonly ApplicationDBContext _context = context;
        public async Task MoveDepartmentToAnotherCompanyAsync(TransfereDepartmentDto transfereDepartmentDto)
        {
            var department = await _context.Departments.FindAsync(transfereDepartmentDto.DepartmentId);
            if (department == null)
            {
                throw new ArgumentException($"Department with Id {transfereDepartmentDto.DepartmentId} not found.");
            }

            var company = await _context.Companies.FindAsync(transfereDepartmentDto.CompanyId);
            if (company == null)
            {
                throw new ArgumentException($"Company with Id {transfereDepartmentDto.CompanyId} not found.");
            }

            var targetCompany = await _context.Companies.FindAsync(transfereDepartmentDto.TargetCompanyId);
            if (targetCompany == null)
            {
                throw new ArgumentException($"Target Company with Id {transfereDepartmentDto.TargetCompanyId} not found.");
            }

            company.Departments.Remove(department);

            targetCompany.Departments.Add(department);

            await _context.SaveChangesAsync();
        }
    }
}