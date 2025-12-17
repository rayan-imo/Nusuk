namespace Nusuk.Services.Dtos;

public class CaravanDto
{
    public string? Name { get; set; }
    public DateTime? DepartureDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? DepartureCity { get; set; }
    public bool IsCompleted { get; set; }
}
