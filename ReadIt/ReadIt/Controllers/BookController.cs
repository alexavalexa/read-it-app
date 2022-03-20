using Microsoft.AspNetCore.Mvc;
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

namespace ReadIt.Controllers
{
    public class BookController : Controller
    {
        private BookService bookService;
        private UserManager<User> userManager;

        public BookController(BookService bookService, UserManager<User> userManager)
        {
            this.bookService = bookService;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            List<BookDTO> books = bookService.GetAll();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            bookService.Create(book, user);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            bookService.Edit(book.Id, book.Title, book.Author);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Book book = bookService.GetById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            bookService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
    

