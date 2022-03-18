using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Models
{
    public class LibraryDbContext : IdentityDbContext (User, IdentityRole<int>, int)
    {
    }
}
