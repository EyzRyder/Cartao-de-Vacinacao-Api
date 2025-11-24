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


public record VaccinationRecordCreateDto
(
    Dose Dose,
    DateTime DateAplication,
    Guid PersonId ,
    Guid VaccinId
);
