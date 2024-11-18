using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public double Price { get; set; }

        public DateTime DateOfPublication { get; set; }

    }
}
