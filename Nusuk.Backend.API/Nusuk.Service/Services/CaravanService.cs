using FluentValidation;
using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Caravan;

namespace Nusuk.Services.Services;

public class CaravanService(IUnitOfWork _uow) : ICaravanService
{
    public async Task<PagedResult<Caravan>> GetAllAsync(PaginationParameter pagination)
    {
        var caravans = await _uow.CaravanRepository.GetAllAsync();
        var query = caravans.Where(u => u.DeletedAt == null).ToList();
        return await PaginationHelper.ToPagedAsync(query, pagination.PageNumber, pagination.PageSize);

    }
    public async Task<Caravan> GetByIdAsync(Guid id)
    {

        if (id == Guid.Empty)
            throw new ArgumentException("Invalid Trip ID.", nameof(id));


        var caravan = await _uow.CaravanRepository.GetByIdAsync(id);

        if (caravan == null)
            throw new KeyNotFoundException($"Caravan with ID '{id}' was not found.");

        return caravan;
    }
    public async Task<Guid> AddAsync(CaravanDto caravandto)
    {
        await new CaravanValidator().ValidateAndThrowAsync(caravandto);
        var caravan = new Caravan
        {
            Id = Guid.NewGuid(),
            Name = caravandto.Name,
            DepartureDate = caravandto.DepartureDate,
            ReturnDate = caravandto.ReturnDate,
            DepartureCity = caravandto.DepartureCity,
            IsCompleted = caravandto.IsCompleted
        };
        await _uow.CaravanRepository.AddAsync(caravan);
        await _uow.CompleteAsync();
        return caravan.Id;
    }
    public async Task<Guid> UpdateAsync(Guid Id, CaravanDto caravandto)
    {
        var caravan = await _uow.CaravanRepository.GetByIdAsync(Id);
        if (caravan is null || caravan.DeletedAt is not null)
        {
            throw new KeyNotFoundException("Caravan not found");
        }
        await new CaravanValidator().ValidateAndThrowAsync(caravandto);
        caravan.ReturnDate = caravandto.ReturnDate;
        caravan.DepartureDate=caravandto.DepartureDate;
        caravan.DepartureCity=caravandto.DepartureCity;
       caravan.IsCompleted= caravandto.IsCompleted;
        await _uow.CaravanRepository.UpdateAsync(caravan);
        await _uow.CompleteAsync();
        return caravan.Id;
    }
    public async Task DeleteAsync(Guid Id)
    {
        var caravan = await _uow.CaravanRepository.GetByIdAsync(Id);
        if (caravan is null)
        {
            throw new KeyNotFoundException("Caravan not found");
        }
        await _uow.CaravanRepository.DeleteAsync(caravan);
        await _uow.CompleteAsync();
    }
}

