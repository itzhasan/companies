namespace Company.Dtos.Company;
public class CreateCompanyRequestDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
}
