using AuthorBookWebAPI.Data;
using AuthorBookWebAPI.Models;
using System;

namespace AuthorBookWebAPI.Repositories
{
    public class AuthorDetailsRepository : IAuthorDetailsRepository
    {
        private readonly MyContext _context;

        public AuthorDetailsRepository(MyContext context)
        {
            _context = context;
        }

        public AuthorDetails GetAuthorDetails(int id)
        {
            return _context.AuthorDetails.Find(id);
        }

        public List<AuthorDetails> GetAllAuthorDetails()
        {
            return _context.AuthorDetails.ToList();
        }

        public int AddAuthorDetails(AuthorDetails authorDetails)
        {
            _context.AuthorDetails.Add(authorDetails);
            _context.SaveChanges();
            return authorDetails.AuthorDetailsId;
        }

        public void UpdateAuthorDetails(AuthorDetails authorDetails)
        {
            _context.AuthorDetails.Update(authorDetails);
            _context.SaveChanges();
        }

        public void DeleteAuthorDetails(int id)
        {
            var authorDetails = _context.AuthorDetails.Find(id);
            if (authorDetails != null)
            {
                _context.AuthorDetails.Remove(authorDetails);
                _context.SaveChanges();
            }
        }
    }

}
