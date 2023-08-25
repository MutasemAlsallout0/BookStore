using BookStore.API.DTOs.CategoryDto;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repo.GetAllCategoriesAsync();
            return Ok(_mapper.Map<List<CategoryResponse>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category != null)
            {
                return Ok(_mapper.Map<CategoryDetailsResponse>(category));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category categoryToCreate)
        {
            var category = await _repo.CreateAsync(categoryToCreate);

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category categoryToUpdate)
        {
            var category = await _repo.UpdateAsync(id, categoryToUpdate);
            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }
    }
}
