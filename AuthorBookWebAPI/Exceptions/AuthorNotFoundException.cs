namespace AuthorBookWebAPI.Exceptions
{
    public class AuthorNotFoundException: Exception
    {
        public AuthorNotFoundException(string message) : base(message) { }
    }
}
