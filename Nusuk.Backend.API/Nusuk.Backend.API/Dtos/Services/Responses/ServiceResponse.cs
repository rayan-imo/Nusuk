using Nusuk.Core.Entities;

namespace Nusuk.Backend.API.Dtos.Services.Responses
{
    public class ServiceResponse
    {   public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsIncluded { get; set; }
        public string? ProviderName { get; set; }

        public static ServiceResponse Transform(Service service)
        {
            return new ServiceResponse
            {
                Id = service.Id,
                Name=service.Name,
                Description=service.Description,
                Price=service.Price,
                IsIncluded=service.IsIncluded,
                ProviderName=service.ProviderName
            };
        }
    
    }
}
