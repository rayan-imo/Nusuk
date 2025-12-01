using FluentValidation;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Trip;

namespace Nusuk.Services.Services;

public class TripService(IUnitOfWork _uow):ITripService
{
    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        var trips = await _uow.TripRepository.GetAllAsync();
        return trips.Where(u => u.DeletedAt == null);

    }

    public async Task<Trip> GetByIdAsync(Guid id)
    {

        if (id == Guid.Empty)
            throw new ArgumentException("Invalid Trip ID.", nameof(id));


        var trip = await _uow.TripRepository.GetByIdAsync(id);

        if (trip == null)
            throw new KeyNotFoundException($"Trip with ID '{id}' was not found.");

        return trip;
    }
    public async Task<Guid> AddAsync(TripDto tripdto)
    {
        await new TripValidator().ValidateAndThrowAsync(tripdto);
        var trip = new Trip
        {
            Id = Guid.NewGuid(),
            Name = tripdto.Name,
            Description = tripdto.Description,
            StartDate = tripdto.StartDate,
            EndDate = tripdto.EndDate,
        };
        await _uow.TripRepository.AddAsync(trip);
        await _uow.CompleteAsync();
        return trip.Id;
    }
    public async Task<Guid> UpdateAsync(Guid Id, TripDto tripdto)
    {
        var trip = await _uow.TripRepository.GetByIdAsync(Id);
        if (trip is null)
        {
            throw new KeyNotFoundException("Trip not found");
        }
        await new TripValidator().ValidateAndThrowAsync(tripdto);
        trip.Name = tripdto.Name;
        trip.Description = tripdto.Description;
        trip.StartDate = tripdto.StartDate;
        trip.EndDate = tripdto.EndDate;

        await _uow.TripRepository.UpdateAsync(trip);
        await _uow.CompleteAsync();
        return trip.Id;
    }
    public async Task DeleteAsync(Guid Id)
    {
        var trip = await _uow.TripRepository.GetByIdAsync(Id);
        if (trip is null)
        {
            throw new KeyNotFoundException("Trip not found");
        }
        await _uow.TripRepository.DeleteAsync(trip);
        await _uow.CompleteAsync();
    }
}
