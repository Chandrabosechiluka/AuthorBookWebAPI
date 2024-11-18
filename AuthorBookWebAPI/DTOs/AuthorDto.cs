using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.DTOs
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public int TotalBooks { get; set; }
    }
}
