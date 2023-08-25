using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticPagesController : ControllerBase
    {
        private readonly IStaticPagesRepository _repo;
        private readonly IMapper _mapper;

        public StaticPagesController(IStaticPagesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaticPages()
        {
            var staticPageses = await _repo.GetAllAsync();
            return Ok(_mapper.Map<List<StaticPages>>(staticPageses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaticPagesById(int id)
        {
            var staticPages = await _repo.GetByIdAsync(id);
            if (staticPages != null)
            {
                return Ok(_mapper.Map<StaticPages>(staticPages));
            }

            return NotFound();
        }
        
        [HttpGet("page/{slug}")]
        public async Task<IActionResult> GetStaticPageBySlug(string slug)
        {
            var staticPages = await _repo.GetByPageSlugAsync(slug);
            if (staticPages != null)
            {
                return Ok(_mapper.Map<StaticPages>(staticPages));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateStaticPages(StaticPages staticPagesToCreate)
        {
            var staticPages = await _repo.CreateAsync(_mapper.Map<StaticPages>(staticPagesToCreate));

            return CreatedAtAction(nameof(GetStaticPagesById), new { id = staticPages.Id }, _mapper.Map<StaticPages>(staticPages));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaticPages(int id, StaticPages staticPagesToUpdate)
        {

            var staticPages = await _repo.UpdateAsync(id, _mapper.Map<StaticPages>(staticPagesToUpdate));
            if (staticPages != null)
            {
                return Ok(_mapper.Map<StaticPages>(staticPages));
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaticPages(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }



    }
}
