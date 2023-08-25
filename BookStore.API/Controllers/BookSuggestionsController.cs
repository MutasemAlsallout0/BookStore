using BookStore.API.DTOs.BookSuggestionDto.Request;
using BookStore.API.DTOs.BookSuggestionDto.Response;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSuggestionsController : ControllerBase
    {
        private readonly IBookSuggestionsRepository _repo;
        private readonly IMapper _mapper;

        public BookSuggestionsController(IBookSuggestionsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBookSuggestionsMessages()
        {

            var messages = await _repo.GetAllAsync();

            return Ok(_mapper.Map<List<BookSuggestionResponse>>(messages));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookSuggestionsById(int id)
        {
            var bookSuggestions = await _repo.GetById(id);
            if (bookSuggestions != null)
            {
                return Ok(_mapper.Map<BookSuggestionResponse>(bookSuggestions));
            }

            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBookSuggestions(PostBookSuggestionRequest bookSuggestionsRequest)
        {
            var bookSuggestions = _mapper.Map<BookSuggestion>(bookSuggestionsRequest);
            var isAdded = await _repo.AddAsync(bookSuggestions);

            return CreatedAtAction(nameof(GetBookSuggestionsById), new { id = isAdded.Id }, isAdded);

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
