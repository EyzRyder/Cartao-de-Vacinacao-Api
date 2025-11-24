using api.Domain.Enums;

namespace api.Application.DTOs;

public record VaccinationRecordCreateDto
(
    Guid VacinaId,
    Dose Dose,
    DateTime DateAplication
);
