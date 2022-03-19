using ReadIt.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadIt.Models
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; set; }
        public string Author { get; set; }
        
        
        [ForeignKey("User")]
        
        public int UserId { get; set; }        
        public User User { get; set; }

    }
}
