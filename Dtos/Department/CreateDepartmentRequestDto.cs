namespace Company.Dtos.Department;

public record CreateDepartmentRequestDto(
    int CompanyId,
    string Name,
    string Type 
);
