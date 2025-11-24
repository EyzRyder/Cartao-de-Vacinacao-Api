using api.Domain.Enums;

namespace api.Application.DTOs;

public class VaccinationRecordCreateDto
{
    public Guid VacinaId { get; set; }
    public Dose Dose { get; set; }
    public DateTime DateAplication { get; set; } = DateTime.UtcNow;
}
