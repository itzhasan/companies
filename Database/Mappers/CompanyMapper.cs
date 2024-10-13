using Company.Dtos.Company;

namespace Company.Mappers;
public static class CompanyMapper
{
    public static CompanyDto ToCompanyDto(this Company.Models.Company companyModel)
    {
        return new CompanyDto
        {
            Id = companyModel.Id,
            Name = companyModel.Name,
            Type = companyModel.Type,
            Departments = companyModel.Departments.Select(c => c.ToDepartmentDto()).ToList()
        };
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
