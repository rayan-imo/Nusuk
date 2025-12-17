using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Packages.Responses;
using Nusuk.Backend.API.Dtos.Services.Responses;

using Nusuk.Core.Common.Pagination;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Services;
using Nusuk.Services.Validators.Service;
using Nusuk.Services.Validators.Trip;

namespace Nusuk.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServiceService _serviceService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _serviceService.GetAllAsync(pagination);
            return Ok(result?.Items?.Select(ServiceResponse.Transform));
        }
        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse>> GetByIdAsync(Guid id)
        {
            var result = await _serviceService.GetByIdAsync(id);
            if (result is null || id == Guid.Empty)
            {
                return NotFound($"Service with ID {id} not found");
            }
            return ServiceResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddAsync(ServiceDto servicedto)
        {
            await new ServiceValidator().ValidateAndThrowAsync(servicedto);
            var serviceId = await _serviceService.AddAsync(servicedto);
            return Ok(serviceId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdateAsync(Guid Id, ServiceDto servicedto)
        {
            if (Id == Guid.Empty)
                return BadRequest("Invalid ID");

            var trip = await _serviceService.GetByIdAsync(Id);
            if (trip == null)
                return NotFound("Service not found");

            await new ServiceValidator().ValidateAndThrowAsync(servicedto);
            var serviceId = await _serviceService.UpdateAsync(Id, servicedto);
            return Ok(serviceId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
                return NotFound(" Trip not found");

            await _serviceService.DeleteAsync(id);
            return Ok();

        }
    }
}
