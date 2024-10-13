namespace Company.Models;
public class Department
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } = [];
}
