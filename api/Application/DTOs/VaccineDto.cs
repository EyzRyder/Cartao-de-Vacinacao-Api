namespace api.Application.DTOs;

public record VaccineDto
(
    Guid Id,
    string Name
);

public record VaccineCreateDto
(
    string Name
);
