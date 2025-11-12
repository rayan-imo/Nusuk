using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class Caravan:BaseEntity
{
    public string? Name {  get; set; }
    public DateTime? DepartureDate {  get; set; }
    public DateTime? ReturnDate {  get; set; }
    public string? DepartureCity { get; set; }
    public bool IsActive {  get; set; }
    public bool IsCompleted {  get; set; }
    public Booking Booking { get; set; }
    public List<TripPackage> JournyPackages { get; set; }


}
