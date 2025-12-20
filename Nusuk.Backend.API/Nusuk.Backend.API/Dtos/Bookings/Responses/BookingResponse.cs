using Nusuk.Backend.API.Dtos.Packages.Responses;
using Nusuk.Core.Entities;

namespace Nusuk.Backend.API.Dtos.Bookings.Responses
{
    public class BookingResponse
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CaravanId{get;set; }
        public string? PackageName {  get; set; }
      
        public static BookingResponse Transform(Booking booking)
        {
            return new BookingResponse()
            {
                Id = booking.Id,
                Price = booking.Price,
                UserId = booking.UserId,
                CaravanId=booking.CaravanId,
                PackageName =booking.Caravan.TripPackage.Package.Name,
                
               
            };
        }
    }
}
