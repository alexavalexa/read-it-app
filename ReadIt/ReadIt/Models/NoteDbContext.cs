using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Models
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes {get; set;}

        public NoteDbContext (DbContextOptions options): base (options)
        {

        }
             
    }
}
