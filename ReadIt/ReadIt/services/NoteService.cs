using ReadIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Services
{
    public class NoteService
    {
        public Note Create (string title, string text)
        {
            Note note = new Note(title, text);
            return note;
        }
    }
}
