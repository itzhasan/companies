namespace Company.Dtos.Employee;

public record EmployeeDto(
    int Id,
    int DepartmentId,
    string Name,
    int Age
);
