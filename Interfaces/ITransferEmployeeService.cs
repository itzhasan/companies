using Company.Dtos.TransferEmployDto;

namespace Company.Interfaces;
public interface ITransferEmployeeService
{
    Task MoveEmployeeToAnotherDepartmentAsync(TransferEmployeeDto transferEmployeeDto);
}
