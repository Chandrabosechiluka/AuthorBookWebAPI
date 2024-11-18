using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.DTOs
{
    public class AuthorDetailsDto
    {
        public int AuthorDetailsId { get; set; }
        public string Location { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }


    }
}
