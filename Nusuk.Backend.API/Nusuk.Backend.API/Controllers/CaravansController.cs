using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Caravans.Responses;
using Nusuk.Core.Common.Pagination;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Caravan;

namespace Nusuk.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaravansController(ICaravanService _caravanService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CaravanResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _caravanService.GetAllAsync(pagination);
          
            return Ok(result?.Items?.Select(CaravanResponse.Transform));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CaravanResponse>> GetByIdAsync(Guid id)
        {
            var result = await _caravanService.GetByIdAsync(id);
            if (result is null || id == Guid.Empty)
            {
                return NotFound($"Caravan with ID {id} not found");
            }
            return CaravanResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<CaravanResponse>> AddAsync(CaravanDto caravandto)
        {
            await new CaravanValidator().ValidateAndThrowAsync(caravandto);
            var caravanId = await _caravanService.AddAsync(caravandto);
            return Ok(caravanId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CaravanResponse>> UpdateAsync(Guid id, CaravanDto caravandto)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var caravan = await _caravanService.GetByIdAsync(id);
            if (caravan == null)
                return NotFound("Caravan not found");


            await new CaravanValidator().ValidateAndThrowAsync(caravandto);
            var caravanId = await _caravanService.UpdateAsync(id, caravandto);
            return Ok(caravanId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var caravan = await _caravanService.GetByIdAsync(id);
            if (caravan == null)
                return NotFound(" Caravan not found");

            await _caravanService.DeleteAsync(id);
            return Ok();

        }
    }
}
