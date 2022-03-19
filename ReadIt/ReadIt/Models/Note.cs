using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Models
{
    public class Note
    {
        private static int id = 0;
        private int bookId;
        private string text;

        public Note(int bookId, string text)
        {
            id++;
            Id = id;
            BookId = bookId;
            Text = text;
        }

        public int Id { get; }
        public int BookId { get; set; }
        public string Text { get; set; }
    }
}
