using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);
        public void AddAuthor(Author author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(int id);
    }
}
