using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nusuk.Services.Dtos
{
    public class ServiceDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsIncluded { get; set; }
        public string? ProviderName { get; set; }
    }
}
