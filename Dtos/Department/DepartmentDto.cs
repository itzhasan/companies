using Company.Dtos.Employee;

namespace Company.Dtos.Department;

public record DepartmentDto(
    int Id ,
    int CompanyId ,
    string Name ,
    string Type ,
    List<EmployeeDto> Employees
);
