using api.Domain.Entities;
using api.Domain.Enums;

namespace api.Application.DTOs;

public record VaccinationRecordDto
(
    Guid Id,
    PersonDto Person ,
    VaccineDto Vaccine,
    Dose Dose ,
    DateTime DateAplication
);


public record VaccinationRecordCreateDto
(
    Dose Dose,
    Guid PersonId ,
    Guid VaccineId
);
