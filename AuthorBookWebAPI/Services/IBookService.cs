using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Services
{
    
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        public BookDto GetBookById(int id);
        public int AddBook(BookDto bookDto);
        public bool UpdateBook(BookDto bookDto);
        public bool DeleteBook(int id);

        public List<BookDto> GetBooksByAuthorId(int authorId);
    }

}
