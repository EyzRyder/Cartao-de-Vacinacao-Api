using api.Domain.Enums;

namespace api.Domain.Entities;

public class VaccinationRecord
{
 public Guid Id { get; set; } = Guid.NewGuid();

    public Guid PersonId { get; set; }
    public Person Person { get; set; } = default!;

    public Guid VaccineId { get; set; }
    public Person Vaccine { get; set; } = default!;

    public Dose Dose { get; set; }   // será salva como string no banco
    public DateTime DateAplication { get; set; } = DateTime.UtcNow;
}
