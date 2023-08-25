using BookStore.API.DTOs.PublisherDto;
using BookStore.API.Helpers;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Interfaces.Services;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repo;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public PublisherController(IPublisherRepository repo,IMapper mapper,IImageService imageService)
        {
            _repo = repo;
            _mapper = mapper;
            _imageService = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublishers([FromQuery] PublisherParams publisherParams)
        {
            var publishers = await _repo.GetAllPublishersAsync(publisherParams);

            return Ok(_mapper.Map<List<PublisherResponse>>(publishers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisher = await _repo.GetPublisherByIdAsync(id);
            if (publisher != null)
            {
                return Ok(_mapper.Map<PublisherDetailsResponse>(publisher));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromForm]PostPublisherRequest publisherToCreate)
        {
           var logo = await _imageService.UploadImage(publisherToCreate.LogoImage);

            if (logo == "") return BadRequest("File is not image ");

            var publisher = new Publisher { Name = publisherToCreate.Name, Logo = logo };

            await _repo.CreateAsync(publisher);

            return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id,[FromForm] PutPublisherRequest putPublisherRequest)
        {
            var publisherToUpdate = new Publisher();
          
            if(putPublisherRequest.LogoImage != null)
            {
                var logo =await  _imageService.UploadImage(putPublisherRequest.LogoImage);

                if (logo == "") return BadRequest("File is not image ");
                publisherToUpdate.Logo = logo;
            }

            publisherToUpdate.Name = putPublisherRequest.Name;
            
            var updatedPublisher=  await _repo.UpdateAsync(id, publisherToUpdate);
            if (updatedPublisher != null)
            {
                return Ok(_mapper.Map<PublisherResponse>(updatedPublisher));
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }
    }
}
