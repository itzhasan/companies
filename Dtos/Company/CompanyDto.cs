using Company.Dtos.Department;

namespace Company.Dtos.Company;
public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();
}
