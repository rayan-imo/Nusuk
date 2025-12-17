using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Packages.Responses;
using Nusuk.Backend.API.Dtos.Users.Responses;
using Nusuk.Core.Common.Pagination;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Validators.Package;

namespace Nusuk.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController(IPackageService _packageService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PackageResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _packageService.GetAllAsync(pagination);

            return Ok(result?.Items?.Select(PackageResponse.Transform));
        }
        [HttpGet("id")]
        public async Task<ActionResult<PackageResponse>> GetByIdAsync(Guid id)
        {
            var result = await _packageService.GetByIdAsync(id);
            if (result is null || id == Guid.Empty)
            {
                return NotFound($"Package with ID {id} not found");
            }
            return PackageResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<PackageResponse>> AddAsync(PackageDto packagedto)
        {
            await new PackageValidator().ValidateAndThrowAsync(packagedto);
            var packageId = await _packageService.AddAsync(packagedto);
            return Ok(packageId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PackageResponse>> UpdateAsync(Guid id, PackageDto packagedto)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var package = await _packageService.GetByIdAsync(id);
            if (package == null)
                return NotFound("Package not found");


            await new PackageValidator().ValidateAndThrowAsync(packagedto);
            var packageId = await _packageService.UpdateAsync(id, packagedto);
            return Ok(packageId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var package = await _packageService.GetByIdAsync(id);
            if (package == null)
                return NotFound(" Package not found");

            await _packageService.DeleteAsync(id);
            return Ok();

        }
    }
}
