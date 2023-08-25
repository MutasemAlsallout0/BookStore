using BookStore.API.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }
        
        [HttpGet("{fileName}")]
        public ActionResult<byte[]> GetImage(string fileName)
        {

            var imagePath = _imageService.GetUploadedImage(fileName);
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);

            return File(imageBytes, "image/jpeg");
        }
    }
}
