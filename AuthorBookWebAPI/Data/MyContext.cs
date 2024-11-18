using AuthorBookWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AuthorBookWebAPI.Data
{
    public class MyContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }
}
