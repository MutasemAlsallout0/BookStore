using BookStore.API.DTOs.AuthorDto;
using BookStore.API.DTOs.BookDto.Repsonse;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _repo.GetAllAuthorsAsync();
            return Ok(_mapper.Map<List<AuthorResponse>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _repo.GetAuthorByIdAsync(id);
            if(author != null)
            {
                return Ok(_mapper.Map<AuthorDeatilsResponse>(author));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author authorToCreate)
        {
            var author = await _repo.CreateAsync(authorToCreate);

            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id , Author authorToUpdate)
        {
            var author = await _repo.UpdateAsync(id, authorToUpdate);
            if(author != null)
            {
                return Ok(author);
            }

            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }



        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAuthorBooks(int id)
        {
            var books = await _repo.GetAuthorBooksAsync(id);
            var booksResponse = _mapper.Map<List<BookResponse>>(books);
            return Ok(booksResponse);
        }


    }
}
