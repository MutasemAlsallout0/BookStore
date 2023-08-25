using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository _repo;

        public ZoneController(IZoneRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllZones()
        {
            return Ok(await _repo.GetAllZonesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZoneById(int id)
        {
            var zone = await _repo.GetZoneByIdAsync(id);
            if (zone != null)
            {
                return Ok(zone);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateZone(Zone zoneToCreate)
        {
            var zone = await _repo.CreateAsync(zoneToCreate);

            return CreatedAtAction(nameof(GetZoneById), new { id = zone.Id }, zone);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateZone(int id, Zone zoneToUpdate)
        {
            var zone = await _repo.UpdateAsync(id, zoneToUpdate);
            if (zone != null)
            {
                return Ok(zone);
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }
    }
}
