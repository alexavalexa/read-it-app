using ReadIt.Models;
using ReadIt.Models.DTO;
using ReadIt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Services
{
    public class NoteService
    {
        private readonly LibraryDbContext dbContext;

        public NoteService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Note Create(string title, string text)
        {
            Note note = new Note(title, text);
           

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();

            return note;
        }

        public Note GetById(int id)
        {
            return dbContext.Notes.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(int id)
        {
            Note dbNote = GetById(id);
            dbContext.Notes.Remove(dbNote);
            dbContext.SaveChanges();
        }

        public Note Edit(int id, string title, string text)
        {
            Note note = GetById(id);
            

           note.Title = note.Title;
            note.Text = note.Text;

            dbContext.SaveChanges();

            return note;
        }


        public void Create(Note note, User user)
        {
            note.User = user;

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
        }

        private static NoteDTO ToDto(Note p)
        {
         NoteDTO note = new NoteDTO();

            note.Id = p.Id;
            note.Title = p.Title;
            note.Text = p.Text;
            
            note.CreatedBy = $"{p.User.FirstName} {p.User.LastName}";
            note.UserEmail = p.User.Email;

            return note;
        }

        public List<NoteDTO> GetAll()
        {
            return dbContext.Notes
                .Include(p => p.User)
                .Select(p => ToDto(p))
                .ToList();
        }

    }
}
