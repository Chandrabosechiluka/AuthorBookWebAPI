using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _authorDetailsService;

        public AuthorDetailsController(IAuthorDetailsService authorDetailsService)
        {
            _authorDetailsService = authorDetailsService;
        }

        [HttpGet]
        public ActionResult<List<AuthorDetailsDto>> GetAllAuthorDetails()
        {
            var authorDetails = _authorDetailsService.GetAllAuthorDetails();
            return Ok(authorDetails);  
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDetailsDto> GetAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsService.GetAuthorDetails(id);
            if (authorDetails != null)
            {
                return Ok(authorDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var newAuthorDetailsId = _authorDetailsService.AddAuthorDetails(authorDetailsDto);
            return CreatedAtAction(nameof(GetAuthorDetails), new { id = newAuthorDetailsId }, authorDetailsDto);
        }

        [HttpPut]
        public IActionResult UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            bool result = _authorDetailsService.UpdateAuthorDetails(authorDetailsDto);

            if (result)
            {
                return Ok(authorDetailsDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorDetails(int id)
        {
            bool result = _authorDetailsService.DeleteAuthorDetails(id);
            if (result)
            {
                return Ok("Deleted Successfully"); 
            }

            return NotFound("Author Details with the given Id is not Found");
        }

        [HttpGet("AuthorDetails/{authorId}")]
        public ActionResult<AuthorDetailsDto> GetAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetailsDto = _authorDetailsService.GetAuthorDetailsByAuthorId(authorId);
            if (authorDetailsDto == null)
            {
                return NotFound("No Author Details Found"); 
            }

            return Ok(authorDetailsDto); 
        }
    }


}
