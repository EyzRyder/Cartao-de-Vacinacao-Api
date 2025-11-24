using api.Domain.Enums;

namespace api.Application.DTOs;

public class VaccinationRecordDto
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid VaccinId { get; set; }
    public Dose Dose { get; set; }
    public DateTime DateAplication { get; set; }
}
