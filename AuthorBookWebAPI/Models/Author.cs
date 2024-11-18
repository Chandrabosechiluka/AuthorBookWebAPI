namespace AuthorBookWebAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public AuthorDetails? AuthorDetails { get; set; }

        public List<Book>? Books { get; set; }
    }
}
