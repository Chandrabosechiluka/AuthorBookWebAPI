using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            var authors = _authorService.GetAllAuthors(); 
            return Ok(authors); 
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetAuthor(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorDto authorDto)
        {
            var newAuthorId = _authorService.AddAuthor(authorDto); 
            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthorId }, authorDto);
        }

        [HttpPut]
        public IActionResult UpdateAuthor(AuthorDto authorDto)
        {
            bool result = _authorService.UpdateAuthor(authorDto);  

            if (result)
            {
                return Ok(authorDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            bool result = _authorService.DeleteAuthor(id); 
            if (result)
            {
                return NoContent(); 
            }

            return NotFound();
        }

        [HttpGet("Name")]
        public ActionResult<AuthorDto> GetAuthorByName(string authorName)
        {
            var authorDto = _authorService.GetAuthorByName(authorName);
            if (authorDto != null)
            {
                return Ok(authorDto);
                
            }
            return NotFound("No Such Authors Exist");

        }

        [HttpGet("book/{bookId}")]
        public ActionResult<AuthorDto> GetAuthorByBookId(int bookId)
        {
            var authorDto = _authorService.GetAuthorByBookId(bookId);

            if (authorDto == null)
            {
                return NotFound("No Such Book Id Exists"); 
            }

            return Ok(authorDto);
        }
    }

}
