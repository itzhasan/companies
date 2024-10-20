namespace Company.Models;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<Department> Departments { get; set; } = [];
}