using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Bookings.Responses;
using Nusuk.Core.Common.Pagination;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Booking;

namespace Nusuk.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService _bookingService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BookingResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _bookingService.GetAllAsync(pagination);
            var x = result.Items;

            return Ok(result?.Items?.Select(BookingResponse.Transform));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingResponse>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var result = await _bookingService.GetByIdAsync(id);
            
            if (result is null)
            {
                return NotFound($"Booking with ID {id} not found");
            }
            return BookingResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<BookingResponse>> AddAsync(BookingDto bookingDto)
        {
            await new BookingValidator().ValidateAndThrowAsync(bookingDto);
            var bookingId = await _bookingService.AddAsync(bookingDto);
            return Ok(bookingId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BookingResponse>> UpdateAsync(Guid id,BookingDto bookingDto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var booking= await _bookingService.GetByIdAsync(id);
            if(booking is null)
            {
                return NotFound($"Booking with ID {id} not found");
            }
            var bookingId=await _bookingService.UpdateAsync(id, bookingDto);
            return Ok(bookingId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking is null )
            {
                return NotFound($"Booking with ID {id} not found");
            }
            await _bookingService.DeleteAsync(id);
            return Ok();
        }

    }
}

