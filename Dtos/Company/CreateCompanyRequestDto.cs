namespace Company.Dtos.Company;

public record CreateCompanyRequestDto(
    int Id,
    string Name,
    string Type
);
