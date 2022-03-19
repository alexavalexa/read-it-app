using ReadIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Services
{
    public interface INoteService
    {
        List<Note> GetAll();
        Note Add(int bookId, string text);
        Note Delete(int id);
        Note Edit(int id, int bookId, string text);
        Note GetById(int id);
    }
}
