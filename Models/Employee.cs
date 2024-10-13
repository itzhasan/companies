namespace Company.Models;
public class Employee
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
