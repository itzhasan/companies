namespace Company.Dtos.Employee;
public class CreateEmployeeRequestDto
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}