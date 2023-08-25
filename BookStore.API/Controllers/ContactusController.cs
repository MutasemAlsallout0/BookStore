using BookStore.API.DTOs.ContactusDto.Request;
using BookStore.API.DTOs.ContactusDto.Response;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {
        private readonly IContactusRepository _repo;
        private readonly IMapper _mapper;

        public ContactusController(IContactusRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContactusMessages()
        {

            var messages =  await _repo.GetAllAsync();

            return Ok(_mapper.Map<List<ContactusMessageResponse>>(messages));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactusById(int id)
        {
            var contactus = await _repo.GetById(id);
            if(contactus != null)
            {
                return Ok(_mapper.Map<ContactusMessageResponse>(contactus));
            }

            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> CreateContactus(PostContactusRequest contactusRequest)
        {
            var contactus = _mapper.Map<Contactus>(contactusRequest);
            var isAdded = await _repo.AddAsync(contactus);

            return CreatedAtAction(nameof(GetContactusById), new { id = isAdded.Id }, isAdded);

        }


        [HttpPut("{id}/mark-read")]
        public async Task<IActionResult> MarkMessageAsRead(int id)
        {
            var isUpdated = await _repo.MarkAsRead(id);

            if (isUpdated)
            {
                return NoContent();
            }

            return BadRequest();
        }


        [HttpPut("{id}/mark-unread")]
        public async Task<IActionResult> MarkMessageAsUnRead(int id)
        {
            var isUpdated = await _repo.MarkAsUnread(id);

            if (isUpdated)
            {
                return NoContent();
            }

            return BadRequest();
        }

    }
}
