using FluentValidation;
using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Package;
using Nusuk.Services.Validators.Trip;

namespace Nusuk.Services.Services
{
    public class PackageService(IUnitOfWork _uow) : IPackageService
    {
        public async Task<PagedResult<Package>> GetAllAsync(PaginationParameter pagination)
        {
            var packages = await _uow.PackageRepository.GetAllAsync();
            var query= packages.Where(u => u.DeletedAt == null).ToList();
            return await PaginationHelper.ToPagedAsync(query, pagination.PageNumber, pagination.PageSize);

        }

        public async Task<Package> GetByIdAsync(Guid id)
        {

            if (id == Guid.Empty)
                throw new ArgumentException("Invalid Trip ID.", nameof(id));


            var package = await _uow.PackageRepository.GetByIdAsync(id);

            if (package == null)
                throw new KeyNotFoundException($"Package with ID '{id}' was not found.");

            return package;
        }
        public async Task<Guid> AddAsync(PackageDto packagedto)
        {
            await new PackageValidator().ValidateAndThrowAsync(packagedto);
            var package = new Package
            {
                Id = Guid.NewGuid(),
                Name = packagedto.Name,
                Description = packagedto.Description,
                TotalPrice = packagedto.TotalPrice,
                IsActive = packagedto.IsActive,
                Level = packagedto.Level

            };
            await _uow.PackageRepository.AddAsync(package);
            await _uow.CompleteAsync();
            return package.Id;
        }
        public async Task<Guid> UpdateAsync(Guid Id, PackageDto packagedto)
        {
            var package = await _uow.PackageRepository.GetByIdAsync(Id);
            if (package is null || package.DeletedAt is not null)
            {
                throw new KeyNotFoundException("package not found");
            }
            await new PackageValidator().ValidateAndThrowAsync(packagedto);
            
            package.Name=packagedto.Name;
            package.Description=packagedto.Description;
            package.Level=packagedto.Level;
            package.IsActive=packagedto.IsActive;
            package.TotalPrice=packagedto.TotalPrice;

            await _uow.PackageRepository.UpdateAsync(package);
            await _uow.CompleteAsync();
            return package.Id;
        }
        public async Task DeleteAsync(Guid Id)
        {
            var package = await _uow.PackageRepository.GetByIdAsync(Id);
            if (package is null)
            {
                throw new KeyNotFoundException("Package not found");
            }
            await _uow.PackageRepository.DeleteAsync(package);
            await _uow.CompleteAsync();
        }
    }
}
