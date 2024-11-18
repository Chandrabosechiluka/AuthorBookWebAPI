using AuthorBookWebAPI.Data;
using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MyContext _context;

        public BookRepository(MyContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int id) => _context.Books.Find(id);

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
