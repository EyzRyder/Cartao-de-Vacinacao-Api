namespace api.Domain.Entities;

public class Vaccine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    // using string.Empty; just to stop the possably null error, but i guess its secure too

}
