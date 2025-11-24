using api.Domain.Enums;

namespace api.Application.DTOs;

public record VaccinationRecordDto
(
    Guid Id,
    Guid PersonId ,
    Guid VaccinId,
    Dose Dose ,
    DateTime DateAplication
);
