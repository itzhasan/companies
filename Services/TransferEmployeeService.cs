using Company.Data;
using Company.Dtos.TransferEmployDto;
using Company.Interfaces;

namespace Company.Services;
    public class TransferEmployeeService(ApplicationDBContext context) : ITransferEmployeeService
    {
        private readonly ApplicationDBContext _context = context;
        public async Task MoveEmployeeToAnotherDepartmentAsync(TransferEmployeeDto transferEmployeeDto)
        {
             var employee = await _context.Employees.FindAsync(transferEmployeeDto.EmployeeId);
            if (employee == null)
            {
                throw new ArgumentException($"Employ with Id {transferEmployeeDto.EmployeeId} not found.");
            }

            var department = await _context.Departments.FindAsync(transferEmployeeDto.DepartmentId);
            if (department == null)
            {
                throw new ArgumentException($"Department with Id {transferEmployeeDto.DepartmentId} not found.");
            }

            var targetDepartment = await _context.Departments.FindAsync(transferEmployeeDto.TargetDepartmentId);
            if (targetDepartment == null)
            {
                throw new ArgumentException($"Target Department with Id {transferEmployeeDto.TargetDepartmentId} not found.");
            }

            employee.DepartmentId = transferEmployeeDto.DepartmentId;

            await _context.SaveChangesAsync();
        }
    }
