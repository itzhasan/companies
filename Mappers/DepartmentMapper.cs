using Company.Dtos.Department;
using Company.Models;

namespace Company.Mappers;
public static class DepartmentMapper
{
    public static DepartmentDto ToDepartmentDto(this Department departmentModel)
    {
        return new DepartmentDto
        {
            Id = departmentModel.Id,
            CompanyId = departmentModel.CompanyId,
            Name = departmentModel.Name,
            Type = departmentModel.Type,
            Employees = departmentModel.Employees.Select(c => c.ToEmployeeDto()).ToList()
        };

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
