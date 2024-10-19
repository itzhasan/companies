using Company.Dtos.Department;

namespace Company.Dtos.Company;

public record CompanyDto(
     int Id ,
     string Name ,
     string Type ,
     List<DepartmentDto> Departments
);
