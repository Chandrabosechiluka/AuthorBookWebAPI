using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Repositories
{
    public interface IAuthorDetailsRepository
    {
        public AuthorDetails GetAuthorDetails(int id);
        public List<AuthorDetails> GetAllAuthorDetails();
        public int AddAuthorDetails(AuthorDetails authorDetails);
        public void UpdateAuthorDetails(AuthorDetails authorDetails);
        public void DeleteAuthorDetails(int id);
    }
}
