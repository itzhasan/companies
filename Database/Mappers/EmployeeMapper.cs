using Company.Dtos.Employee;
using Company.Models;

namespace Company.Mappers;

public static class EmployeeMapper //use record instead of class ( google class vs record)
{
    public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
    {
        return new EmployeeDto
        {
            Id = employeeModel.Id,
            Name = employeeModel.Name,
            Age = employeeModel.Age,
        };
    }

    public static Employee ToEmployeeFormCreateDTO(this CreateEmployeeRequestDto employeeDto, int departmentId)
    {
        return new Employee
        {
            DepartmentId = departmentId,
            Name = employeeDto.Name,
            Age = employeeDto.Age,
        };
    }
}
