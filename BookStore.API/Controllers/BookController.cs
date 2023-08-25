
using BookStore.API.DTOs.BookDto.Repsonse;
using BookStore.API.DTOs.BookDto.Request;
using BookStore.API.DTOs.BookReviewsDto.Request;
using BookStore.API.DTOs.BookReviewsDto.Response;
using BookStore.API.Helpers;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Interfaces.Services;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IImageService _imageService;

        public BookController(IBookRepository repo,IMapper mapper,UserManager<AppUser> userManager,IImageService imageService)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _imageService = imageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery]BookParams bookParams)
        {
            var books = await _repo.GetAllBooksAsync(bookParams);

            
            var booksResponse = _mapper.Map<List<BookResponse>>(books);
            return Ok(booksResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _repo.GetBookByIdAsync(id);
            if (book != null)
            {
                return Ok(_mapper.Map<BookDetailsResponse>(book));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm]CreateBookRequest createBookRequest)
        {
            var fileName =await _imageService.UploadImage(createBookRequest.ImageFile);
            if (fileName == "") return BadRequest("File is not image");

            var bookToCreate = _mapper.Map<Book>(createBookRequest);
            bookToCreate.Image = fileName;

            var book = await _repo.CreateAsync(bookToCreate);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, _mapper.Map<BookDetailsResponse>(book));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromForm]UpdateBookRequest updateBookRequest)
        {
            var bookToUpdate = _mapper.Map<Book>(updateBookRequest);

            if(updateBookRequest.ImageFile != null)
            {
                var fileName = await _imageService.UploadImage(updateBookRequest.ImageFile);
                bookToUpdate.Image = fileName;
            }


            var book = await _repo.UpdateAsync(id, bookToUpdate);
            if (book != null)
            {
                return Ok(_mapper.Map<BookDetailsResponse>(book));
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var isDeleted = await _repo.DeleteAsync(id);
            if (isDeleted) return Ok();

            return BadRequest();
        }


        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestBook()
        {
            var book = await _repo.GetLatestBookAsync();
            if(book != null)
            {
                return Ok(_mapper.Map<SpecficBookResponse>(book));
            }

            return BadRequest();
        }


        [HttpPost("{bookId}/add-to-favorite")]
        [Authorize]
        public async Task<IActionResult> AddBookToFavorite(int bookId)
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
            // var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var result = await _repo.AddToFavorite(userId,bookId);
            if (result)
            {
                var book = await _repo.GetBookByIdAsync(bookId);

                return Ok(_mapper.Map<BookResponse>(book));
            }

            return BadRequest("ids are wrong or book is already added");
        }

         [HttpDelete("{bookId}/remove-from-favorite")]
        public async Task<IActionResult> RemoveBookFromFavorite(int bookId)
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
            // var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var result = await _repo.RemoveFromFavorite(userId,bookId);
            if (result)
            {
                return NoContent();
            }

            return BadRequest("ids are wrong or the record not in database");
        }


        [HttpGet("favorite-books")]
        public async Task<IActionResult> GetUserFavoriteBooks()
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
            //  var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var books = await _repo.GetUserFavoriteBooks(userId);

            return Ok(_mapper.Map<List<BookResponse>>(books));

        }


        [HttpPost("{bookId}/add-review")]
        public async Task<IActionResult> AddReview(int bookId,AddBookReviewRequest addBookReviewRequest)
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
            // var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var reviewToAdd = _mapper.Map<BookReviews>(addBookReviewRequest);
            reviewToAdd.AppUserId = userId;
            reviewToAdd.BookId = bookId;

            var isCreated = await _repo.AddReview(reviewToAdd);
            if (isCreated != null)
            {
                return CreatedAtAction(nameof(GetBookById), new { id = isCreated.BookId }, _mapper.Map<DisplaySpecficBookReviewResponse>(isCreated));
            }

            return BadRequest();
        }


        [HttpDelete("review/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var isDeleted = await _repo.RemoveReview(id);
            if (isDeleted) return NoContent();

            return BadRequest();
        }


        [HttpGet("{bookId}/reviews")]
        public async Task<IActionResult> GetBookReviews(int bookId)
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
           // var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");
           

            var bookReviews = await _repo.GetBookReviews(bookId);
            if (bookReviews != null)
            {
                return Ok(_mapper.Map<List<DisplaySpecficBookReviewResponse>>(bookReviews));
            }

            return BadRequest();
        }

        [HttpGet("user-reviews")]
        public async Task<IActionResult> GetUserReviews()
        {
            //Here we get Authenticted user 
            // this code is for testing purpose only until we implement authnetication
            //  var user = await _userManager.FindByIdAsync("b5feebcf-f317-4117-81c5-f95c98e3999e");
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var userReviews = await _repo.GetUserReviews(userId);
            if (userId != null)
            {
                return Ok(_mapper.Map<List<DisplaySpecficBookReviewResponse>>(userReviews));
            }

            return BadRequest();

        }

    }
}
