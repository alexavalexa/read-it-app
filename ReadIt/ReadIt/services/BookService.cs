using ReadIt.Models;
using ReadIt.Models.DTO;
using ReadIt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.services
{
    public class BookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Book Create(string title, string author)
        {
            Book Book = new Book(title, author);


            dbContext.Books.Add(Book);
            dbContext.SaveChanges();

            return Book;
        }

        public Book GetById(int id)
        {
            return dbContext.Books.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(int id)
        {
            Book dbBook = GetById(id);
            dbContext.Books.Remove(dbBook);
            dbContext.SaveChanges();
        }

        public void Create(Book book, User user)
        {
            book.User = user;

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }


        public Book Edit(int id, string title, string author)
        {
            Book book = GetById(id);


            book.Title = book.Title;
            book.Author = book.Author;

            dbContext.SaveChanges();

            return book;
        }

        private static BookDTO ToDto(Book p)
        {
            BookDTO book = new BookDTO();

            book.Id = p.Id;
            book.Title = p.Title;
            book.Author = p.Author;

            book.CreatedBy = $"{p.User.FirstName} {p.User.LastName}";
            book.UserEmail = p.User.Email;

            return book;
        }

        public List<BookDTO> GetAll()
        {
            return dbContext.Books
                .Include(p => p.User)
                .Select(p => ToDto(p))
                .ToList();
        }
    }
}

    


