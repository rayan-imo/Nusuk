using FluentValidation;
using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Booking;
using Nusuk.Services.Validators.Caravan;
using System.Runtime.InteropServices;

namespace Nusuk.Services.Services;

public class BookingService(IUnitOfWork _uow) : IBookingService
{
    public async Task<PagedResult<Booking>> GetAllAsync(PaginationParameter pagination)
    {
        var bookings = await _uow.BookingRepository.GetAllAsync();
        var query = bookings.Where(u => u.DeletedAt == null).ToList();
        return await PaginationHelper.ToPagedAsync(query, pagination.PageNumber, pagination.PageSize);
    }
    public async Task<Booking> GetByIdAsync(Guid id)
    {

        if (id == Guid.Empty)
            throw new ArgumentException("Invalid Trip ID.", nameof(id));


        var booking = await _uow.BookingRepository.GetByIdWithAllIncludes(id);

        if (booking == null)
            throw new KeyNotFoundException($"Booking with ID '{id}' was not found.");

        return booking;
    }
    public async Task<Guid> AddAsync(BookingDto bookingDto)
    {
        var user = await _uow.UsersRepository.GetByItemAsync(x => x.Id == bookingDto.UserId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var caravan = await _uow.CaravanRepository.GetByItemAsync(x => x.Id == bookingDto.CaravanId);
        if (caravan == null)
        {
            throw new Exception("Caravan not found");
        }
        await new BookingValidator().ValidateAndThrowAsync(bookingDto);

        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            User = user,
            CaravanId = bookingDto.CaravanId,
            RoleId = bookingDto.RoleId,
            UserId = user.Id,
            Price = bookingDto.Price
        };
        await _uow.BookingRepository.AddAsync(booking);
        await _uow.CompleteAsync();
        return booking.Id;
    }

    public async Task<Guid> UpdateAsync(Guid Id, BookingDto bookingDto)
    {
        var booking = await _uow.BookingRepository.GetByItemAsync(x => x.Id == Id);
        if (booking == null)
        {
            throw new Exception("Booking not Found");
        }
        var user = await _uow.UsersRepository.GetByItemAsync(x => x.Id == bookingDto.UserId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var caravan = await _uow.CaravanRepository.GetByItemAsync(x => x.Id == bookingDto.CaravanId);
        if (caravan == null)
        {
            throw new Exception("Caravan not found");
        }
        await new BookingValidator().ValidateAndThrowAsync(bookingDto);
        booking.Price = bookingDto.Price;
        booking.CaravanId= bookingDto.CaravanId;
        booking.UserId=bookingDto.UserId;
        booking.User = user;
        await _uow.BookingRepository.UpdateAsync(booking);
        await _uow.CompleteAsync();
        return booking.Id;
    }

    public async Task DeleteAsync(Guid Id)
    {
        var booking = await _uow.BookingRepository.GetByItemAsync(x => x.Id == Id);
        if (booking == null)
        {
            throw new Exception("Booking not Found");
        }
        await _uow.BookingRepository.DeleteAsync(booking);
        await _uow.CompleteAsync();
    }
}
