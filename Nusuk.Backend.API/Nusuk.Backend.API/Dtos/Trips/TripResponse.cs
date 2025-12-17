using Microsoft.EntityFrameworkCore.Storage.Json;
using Nusuk.Core.Entities;
using Nusuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nusuk.Core.Dtos
{
    public class TripResponse
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public TripType? Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public static TripResponse Transform(Trip trip)
        {
            return new TripResponse
            {
                Name = trip.Name,
                Description = trip.Description,
                Type = trip.Type,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate
            };
        }
    }
}
