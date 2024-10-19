namespace Company.Dtos.TransferDepartmentDto;

public record TransferDepartmentDto(
    int CompanyId,
    int DepartmentId,
    int TargetCompanyId
);
