using ReadIt.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadIt.Models
{
    public class Book
    {
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        
        
        [ForeignKey("User")]
        
        public int UserId { get; set; }        
        public User User { get; set; }

    }
}
