
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadIt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Models
{
    public class LibraryDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Note> Notes {get; set;}
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }


    }
}
