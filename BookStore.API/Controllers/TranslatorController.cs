using BookStore.API.DTOs.TranslatorDto;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslatorRepository _repo;
        private readonly IMapper _mapper;

        public TranslatorController(ITranslatorRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTranslators()
        {
            var translators = await _repo.GetAllTranslatorsAsync();
            return Ok(_mapper.Map<List<TranslatorResponse>>(translators));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTranslatorById(int id)
        {
            var translator = await _repo.GetTranslatorByIdAsync(id);
            if (translator != null)
            {
                return Ok(_mapper.Map<TranslatorDetailsResponse>(translator));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTranslator(Translator translatorToCreate)
        {
            var translator = await _repo.CreateAsync(translatorToCreate);

            return CreatedAtAction(nameof(GetTranslatorById), new { id = translator.Id }, translator);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTranslator(int id, Translator translatorToUpdate)
        {
            var translator = await _repo.UpdateAsync(id, translatorToUpdate);
            if (translator != null)
            {
                return Ok(translator);
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTranslator(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }
    }
}
