using AuthorBookWebAPI.Data;
using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyContext _context;

        public AuthorRepository(MyContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorById(int id) => _context.Authors.Find(id);

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
