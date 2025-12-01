using Nusuk.Core.Enums;

namespace Nusuk.Services.Dtos;

public class TripDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public TripType? Type {  get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
