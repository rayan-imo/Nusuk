using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices
{
    public interface IBookingService
    {
        public Task<PagedResult<Booking>> GetAllAsync(PaginationParameter pagination);
        public Task<Booking> GetByIdAsync(Guid Id);
        public Task<Guid> AddAsync(BookingDto bookingDto);
        public Task<Guid> UpdateAsync(Guid Id, BookingDto bookingDto );
        public Task DeleteAsync(Guid Id);
    }
}
