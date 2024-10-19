using Company.Dtos.Department;
using Company.Dtos.Employee;
using Company.Models;

namespace Company.Mappers;
public static class DepartmentMapper
{
    public static DepartmentDto ToDepartmentDto(this Department departmentModel)
    {
        return new DepartmentDto
        (
            departmentModel.Id,
            departmentModel.CompanyId,
            departmentModel.Name,
            departmentModel.Type,
            departmentModel.Employees.Select( emp => new EmployeeDto(
                emp.Id,
                emp.DepartmentId,
                emp.Name,
                emp.Age
            )).ToList()
        );

    }
    public static Department ToDepartmentFormCreateDTO(this CreateDepartmentRequestDto departmentDto, int companyId)
    {
        return new Department
        {
            CompanyId = companyId,
            Name = departmentDto.Name,
            Type = departmentDto.Type,
        };
    }
}
