using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookDto>> GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);  
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook(BookDto bookDto)
        {
            var newBookId = _bookService.AddBook(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = newBookId }, bookDto);
        }

        [HttpPut]
        public IActionResult UpdateBook(BookDto bookDto)
        {
            bool result = _bookService.UpdateBook(bookDto);

            if (result)
            {
                return Ok(bookDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            bool result = _bookService.DeleteBook(id);
            if (result)
            {
                return NoContent();  
            }

            return NotFound();
        }

        [HttpGet("author/{authorId}")]
        public ActionResult<List<BookDto>> GetBooksByAuthorId(int authorId)
        {
            var booksDto = _bookService.GetBooksByAuthorId(authorId);

            if (booksDto == null || booksDto.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(booksDto); 
        }
    }

}
