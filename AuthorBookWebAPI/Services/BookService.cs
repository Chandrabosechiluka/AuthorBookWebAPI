using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll()
                                        .AsNoTracking()  
                                        .ToList();

            return _mapper.Map<List<BookDto>>(books);
        }

        public BookDto GetBookById(int id)
        {
            var book = _bookRepository.Get(id);
            if (book != null)
            {
                return _mapper.Map<BookDto>(book);
            }

            return null; 
        }

        public int AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Add(book);
            return book.BookId;
        }

        public bool UpdateBook(BookDto bookDto)
        {
            var existingBook = _bookRepository.Get(bookDto.BookId);

            if (existingBook != null)
            {
                _mapper.Map(bookDto, existingBook);
                _bookRepository.Update(existingBook);
                return true;
            }

            return false;
        }

        public bool DeleteBook(int id)
        {
            var book = _bookRepository.Get(id);

            if (book != null)
            {
                _bookRepository.Delete(book);
                return true;
            }

            return false;
        }

        public List<BookDto> GetBooksByAuthorId(int authorId)
        {
            var books = _bookRepository.GetAll()
                                        .Where(b => b.AuthorId == authorId)
                                        .ToList();

            if (books.Count == 0)
            {
                return new List<BookDto>();
            }

            var booksDto = _mapper.Map<List<BookDto>>(books);
            return booksDto;
        }
    }

}
