using Microsoft.AspNetCore.Mvc;
using ReadIt.Models;
using ReadIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Controllers
{
    public class NoteController : Controller
    {
        private INoteService noteService;
        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public IActionResult Index()
        {
            List<Note> notes = noteService.GetAll();
            return View(notes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int bookId, string text)
        {
            noteService.Add(bookId, text);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Note note = noteService.GetById(id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(int id, int bookId, string text)
        {
            noteService.Edit(id, bookId, text);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Note note = noteService.GetById(id);

            return View(note);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            noteService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
