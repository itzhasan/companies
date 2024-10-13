namespace Company.Dtos.Employee;
public class EmployeeDto
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
