namespace AuthorBookWebAPI.Models
{
    public class AuthorDetails
    {
        public int AuthorDetailsId { get; set; }

        public string Location { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
