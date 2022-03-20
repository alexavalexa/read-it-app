﻿using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ReadIt.Models;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadIt.Models.DTO;
using Microsoft.AspNetCore.Identity;
using ReadIt.Models.Entities;
using ReadIt.services;
using ReadIt.Services;

namespace ReadIt.Controllers
{
    public class NoteController : Controller
    {
        private NoteService noteService;
        private UserManager<User> userManager;

        public NoteController(NoteService noteService, UserManager<User> userManager)
        {
            this.noteService = noteService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<NoteDTO> Notes = noteService.GetAll();

            return View(Notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            noteService.Create(note, user);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            noteService.Edit(note.Id, note.Title, note.Text);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Note Note = noteService.GetById(id);
            return View(Note);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            noteService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
