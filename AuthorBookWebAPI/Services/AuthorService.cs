using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Exceptions;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> authorRepository, IMapper mapper, IGenericRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public bool UpdateAuthor(AuthorDto authorDto)
        {
            
            var existingAuthor = _authorRepository.Get(authorDto.AuthorId);

            if (existingAuthor != null)
            {
                
                _mapper.Map(authorDto, existingAuthor);
                _authorRepository.Update(existingAuthor); 
                return true;
            }

            return false;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _authorRepository.Get(id);

            if (author != null)
            {
                _authorRepository.Delete(author);
                return true;
            }

            return false;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAll()
                                            .Include(x => x.Books)    
                                            .Include(x => x.AuthorDetails)
                                            .AsNoTracking()  
                                            .ToList();

            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public AuthorDto GetAuthorById(int id)
        {
            var author = _authorRepository.GetAll().Include(x => x.Books)
                                  .Where(x => x.AuthorId == id).FirstOrDefault();
            if (author == null)
            {
                throw new AuthorNotFoundException("No Such author found");
                
            }
            return _mapper.Map<AuthorDto>(author);

        }

        public int AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Add(author);
            return author.AuthorId;
        }

        public AuthorDto GetAuthorByName(string authorName)
        {
            var author = _authorRepository
                .GetAll().Include(x => x.Books)
                .FirstOrDefault(a => a.AuthorName.Contains(authorName));
            if (author != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;
                
            }
            throw new AuthorNotFoundException("No Such Author Exists");


        }

        public AuthorDto GetAuthorByBookId(int bookId)
        {
            var author = _authorRepository.GetAll()
                                 .Include(a => a.Books)
                                 .FirstOrDefault(a => a.Books.Any(b => b.BookId == bookId));

            if (author != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;
                
            }
            return null;

        }
    }


}

