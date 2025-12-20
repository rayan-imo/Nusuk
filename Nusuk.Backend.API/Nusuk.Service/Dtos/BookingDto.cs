using Nusuk.Core.Entities;
using Nusuk.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Nusuk.Services.Dtos
{
    public class BookingDto
    {
        public decimal Price { get; set; }
      // public DateTime DateTime { get; set; }= DateTime.Now;
        public Guid UserId { get; set; }
        public Guid CaravanId { get; set; }
        public required string PckageName { get; set; }
    }
}
