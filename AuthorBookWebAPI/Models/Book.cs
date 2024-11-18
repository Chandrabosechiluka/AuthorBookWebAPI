namespace AuthorBookWebAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public double Price { get; set; }

        public DateTime DateOfPublication { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
