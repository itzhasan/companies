using Company.Dtos.Employee;

namespace Company.Dtos.Department;
public class DepartmentDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<EmployeeDto> Employees { get; set; } = [];
}
