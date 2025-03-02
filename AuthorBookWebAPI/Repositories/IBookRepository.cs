﻿using AuthorBookWebAPI.Models;

namespace AuthorBookWebAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
