using Company.Data;
using Company.Dtos.TransferDepartmentDto;
using Company.Interfaces;

namespace Company.Services;
public class TransferDepartmentService(ApplicationDBContext context) : ITransferDepartmentService
{
    private readonly ApplicationDBContext _context = context;
    public async Task MoveDepartmentToAnotherCompanyAsync(TransferDepartmentDto transferDepartmentDto)
    {
        var department = await _context.Departments.FindAsync(transferDepartmentDto.DepartmentId);
        if (department == null)
        {
            throw new ArgumentException($"Department with Id {transferDepartmentDto.DepartmentId} not found.");
        }

        var company = await _context.Companies.FindAsync(transferDepartmentDto.CompanyId);
        if (company == null)
        {
            throw new ArgumentException($"Company with Id {transferDepartmentDto.CompanyId} not found.");
        }

        var targetCompany = await _context.Companies.FindAsync(transferDepartmentDto.TargetCompanyId);
        if (targetCompany == null)
        {
            throw new ArgumentException($"Target Company with Id {transferDepartmentDto.TargetCompanyId} not found.");
        }

        department.CompanyId = transferDepartmentDto.TargetCompanyId;

        await _context.SaveChangesAsync();
    }
}
