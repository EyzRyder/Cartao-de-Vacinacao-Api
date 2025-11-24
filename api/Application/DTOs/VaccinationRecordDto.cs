using api.Domain.Enums;

namespace api.Application.DTOs;

public record VaccinationRecordDto
(
    Guid Id,
    Guid PersonId ,
    Guid VaccineId,
    Dose Dose ,
    DateTime DateAplication
);


public record VaccinationRecordCreateDto
(
    Dose Dose,
    Guid PersonId ,
    Guid VaccineId
);
