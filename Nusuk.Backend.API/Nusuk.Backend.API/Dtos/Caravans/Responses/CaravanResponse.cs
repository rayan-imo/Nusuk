using Nusuk.Backend.API.Dtos.Packages.Responses;
using Nusuk.Core.Entities;
namespace Nusuk.Backend.API.Dtos.Caravans.Responses
{
    public class CaravanResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? DepartureCity { get; set; }
        public bool IsCompleted { get; set; }
        public static CaravanResponse Transform(Caravan caravan)
        {
            return new CaravanResponse
            {   Id = caravan.Id,
                Name = caravan.Name,
                DepartureDate = caravan.DepartureDate,
                ReturnDate = caravan.ReturnDate,
                DepartureCity = caravan.DepartureCity,
                IsCompleted = caravan.IsCompleted
            };
        }
    }

}
