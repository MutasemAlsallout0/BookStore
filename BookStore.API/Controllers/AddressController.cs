using BookStore.API.DTOs.AddressDto.Request;
using BookStore.API.DTOs.AddressDto.Response;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repo;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _repo.GetAllAsync();
            return Ok(_mapper.Map<List<AddressResponse>>(addresses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _repo.GetByIdAsync(id);
            if (address != null)
            {
                return Ok(_mapper.Map<AddressResponse>(address));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddress(PostPutAddressRequest addressToCreate)
        {
            var address = await _repo.CreateAsync(_mapper.Map<Address>(addressToCreate));

            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, _mapper.Map<AddressResponse>(address));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, PostPutAddressRequest addressToUpdate)
        {

            var address = await _repo.UpdateAsync(id, _mapper.Map<Address>(addressToUpdate));
            if (address != null)
            {
                return Ok(_mapper.Map<AddressResponse>(address));
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }
    }
}
