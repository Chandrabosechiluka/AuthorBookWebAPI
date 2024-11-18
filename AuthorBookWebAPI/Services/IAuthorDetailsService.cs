using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Services
{
    public interface IAuthorDetailsService
    {
        public AuthorDetailsDto GetAuthorDetails(int id);
        public List<AuthorDetailsDto> GetAllAuthorDetails();
        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto);
        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto);
        public bool DeleteAuthorDetails(int id);

        public AuthorDetailsDto GetAuthorDetailsByAuthorId(int authorId);
    }

}
