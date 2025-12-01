using Nusuk.Core.Enums;

namespace Nusuk.Services.Dtos;

public class PackageDto
{
    public required string Name {  get; set; }
    public string? Description { get; set; }
    public PackageLevel Level { get; set; }
    public bool IsActive { get; set; }
    public decimal? TotalPrice { get; set; }
}
