using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Services
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAllAuthors();
        public AuthorDto GetAuthorById(int id);
        public int AddAuthor(AuthorDto authorDto);
        public bool UpdateAuthor(AuthorDto authorDto);
        public bool DeleteAuthor(int id);

        public AuthorDto GetAuthorByName(string authorName);

        public AuthorDto GetAuthorByBookId(int bookId);
    }
}
