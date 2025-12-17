using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Packages.Responses;

using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Dtos;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Trip;

namespace Nusuk.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController(ITripService _tripService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TripResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _tripService.GetAllAsync(pagination);
            return Ok(result?.Items?.Select(TripResponse.Transform));
        }
        [HttpGet("details")]
        public async Task<IActionResult> GetTripWithDetails()
        {
            var trips = await _tripService.GetTripWithDetails();
            return Ok(trips);
        }
        [HttpGet("id")]
        public async Task<ActionResult<TripResponse>> GetByIdAsync(Guid id)
        {
            var result = await _tripService.GetByIdAsync(id);
            if (result is null || id == Guid.Empty)
            {
                return NotFound($"Trip with ID {id} not found");
            }
            return TripResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<TripResponse>> AddAsync(TripDto tripdto)
        {
            await new TripValidator().ValidateAndThrowAsync(tripdto);
            var tripId = await _tripService.AddAsync(tripdto);
            return Ok(tripId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PackageResponse>> UpdateAsync(Guid id, TripDto tripdto)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var trip = await _tripService.GetByIdAsync(id);
            if (trip == null)
                return NotFound("Trip not found");

            await new TripValidator().ValidateAndThrowAsync(tripdto);
            var tripId = await _tripService.UpdateAsync(id, tripdto);
            return Ok(tripId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var trip = await _tripService.GetByIdAsync(id);
            if (trip == null)
                return NotFound(" Trip not found");

            await _tripService.DeleteAsync(id);
            return Ok();

        }
    }
}
