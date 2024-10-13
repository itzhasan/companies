using Company.Dtos.TransferDepartmentDto;

namespace Company.Interfaces;
public interface ITransferDepartmentService
{
    Task MoveDepartmentToAnotherCompanyAsync(TransferDepartmentDto transferDepartmentDto);
}
