using Company.Dtos.Company;
using Company.Dtos.Department;
using Company.Dtos.Employee;

namespace Company.Mappers;
public static class CompanyMapper
{
    public static CompanyDto ToCompanyDto(this Company.Models.Company companyModel)
    {
        return new CompanyDto(
            companyModel.Id,
            companyModel.Name,
            companyModel.Type,
            companyModel.Departments.Select(dep => new DepartmentDto(
                dep.Id,
                dep.CompanyId,
                dep.Name,
                dep.Type,
                dep.Employees.Select(emp => new EmployeeDto(
                    emp.Id,
                emp.DepartmentId,
                emp.Name,
                emp.Age
                )).ToList()
            )).ToList()
        );
    }
    public static Company.Models.Company ToDepartmentFormCreateDTO(this CreateCompanyRequestDto companyDto)
    {
        return new Company.Models.Company
        {
            Name = companyDto.Name,
            Type = companyDto.Type,
        };
    }
}
