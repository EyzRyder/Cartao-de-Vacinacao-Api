namespace api.Application.DTOs;

public record PersonDto 
(
    Guid Id,
    string Name
);

public record PersonCreateDto
(
    string Name
);