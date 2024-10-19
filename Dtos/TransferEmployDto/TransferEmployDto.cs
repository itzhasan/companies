namespace Company.Dtos.TransferEmployDto;

public record TransferEmployeeDto(
    int DepartmentId,
    int EmployeeId ,
    int TargetDepartmentId 
);
