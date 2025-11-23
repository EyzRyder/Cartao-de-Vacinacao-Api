namespace api.Models;

public class Vaccine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // using string.Empty; just to stop the possably null error, but i guess its secure too

}
