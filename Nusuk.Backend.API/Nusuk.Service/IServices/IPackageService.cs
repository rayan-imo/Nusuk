using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface IPackageService
{
    public Task<PagedResult<Package>> GetAllAsync(PaginationParameter pagination);
    public Task<Package> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(PackageDto packageDto);
    public Task<Guid> UpdateAsync(Guid Id, PackageDto packageDto);
    public Task DeleteAsync(Guid Id);
}

