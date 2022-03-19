using ReadIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Services
{
    public class NoteService : INoteService
    {
        private IData data;
        public NoteService(IData data)
        {
            this.data = data;
        }
        public List<Note> GetAll()
        {
            return data.Notes;
        }

        public Note Add(int bookId, string text)
        {
            Note note = new Note(bookId, text);
            data.Notes.Add(note);
            return note;
        }


        public Note Edit(int id, int bookId, string text)
        {
            Note note = GetById(id);
            note.BookId = bookId;
            note.Text = text;
            return note;
        }
        public Note Delete(int id)
        {
            Note note = GetById(id);
            data.Notes.Remove(note);
            return note;
        }

        public Note GetById(int id)
        {
            return data.Notes.FirstOrDefault(p => p.Id == id);
        }
    }
}
