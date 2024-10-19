namespace Company.Dtos.Employee;

public record CreateEmployeeRequestDto(
    int DepartmentId,
    string Name,
    int Age
);