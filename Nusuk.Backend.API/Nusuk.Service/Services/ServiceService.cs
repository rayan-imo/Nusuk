using FluentValidation;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Service;
using Nusuk.Services.Validators.Trip;

namespace Nusuk.Services.Services
{
    public class ServiceService(IUnitOfWork _uow) : IServiceService
    {
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            var services = await _uow.ServiceRepository.GetAllAsync();
            return services.Where(u => u.DeletedAt == null);

        }

        public async Task<Service> GetByIdAsync(Guid Id)
        {

            if (Id == Guid.Empty)
                throw new ArgumentException("Invalid Trip ID.", nameof(Id));


            var service = await _uow.ServiceRepository.GetByIdAsync(Id);

            if (service == null)
                throw new KeyNotFoundException($"Service with ID '{Id}' was not found.");

            return service;
        }
        public async Task<Guid> AddAsync(ServiceDto servicedto)
        {
            await new ServiceValidator().ValidateAndThrowAsync(servicedto);
            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = servicedto.Name,
                Description = servicedto.Description,
                IsIncluded = servicedto.IsIncluded,
                Price = servicedto.Price
            };
            await _uow.ServiceRepository.AddAsync(service);
            await _uow.CompleteAsync();
            return service.Id;
        }
        public async Task<Guid> UpdateAsync(Guid Id, ServiceDto servicedto)
        {
            var service = await _uow.ServiceRepository.GetByIdAsync(Id);
            if (service is null)
            {
                throw new KeyNotFoundException("Service not found");
            }
            await new ServiceValidator().ValidateAndThrowAsync(servicedto);
            service.Name = servicedto.Name;
            service.Description = servicedto.Description;
            service.IsIncluded = servicedto.IsIncluded;
            service.Price = servicedto.Price;


            await _uow.ServiceRepository.UpdateAsync(service);
            await _uow.CompleteAsync();
            return service.Id;
        }
        public async Task DeleteAsync(Guid Id)
        {
            var service = await _uow.ServiceRepository.GetByIdAsync(Id);
            if (service is null)
            {
                throw new KeyNotFoundException("Service not found");
            }
            await _uow.ServiceRepository.DeleteAsync(service);
            await _uow.CompleteAsync();
        }
    }
}
