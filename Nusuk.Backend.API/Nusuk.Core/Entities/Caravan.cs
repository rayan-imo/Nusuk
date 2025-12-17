using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class Caravan:BaseEntity
{
    public string? Name {  get; set; }
    public DateTime? DepartureDate {  get; set; }
    public DateTime? ReturnDate {  get; set; }
    public string? DepartureCity { get; set; }
    public bool IsCompleted {  get; set; }
    public List<Booking> Bookings { get; set; }
    public TripPackage?  TripPackage { get; set; }
    public Guid? TripPackageId { get; set; }


}
