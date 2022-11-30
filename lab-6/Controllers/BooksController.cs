using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_6.Models;
using MessagePack;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace lab_6.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IClockProvider _clock;
        public BooksController(AppDbContext context,
            IBookService bookService, IClockProvider clock)
        {
            _bookService = bookService;
            _clock = clock;
        }
        public IActionResult Index()
        {
            return View(_bookService.FindAll());
        }
        public IActionResult Details(int? id)
        {
            var book = _bookService.FindBy(id);
            return book is null ? NotFound() : View(book);
        }
        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ReleaseDate,Created")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Save(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Edit(int? id)
        {
            var book = _bookService.FindBy(id);
            return book is null ? NotFound() : View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Created")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _bookService.FindBy(id);
            return book is null ? NotFound() : View(book);
        }
        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_bookService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing book");
        }

        //public string Age(int? id)
        //{
        //    var find = _bookService.FindBy(id);
        //    return find is null
        //    ? "Brak takiej książki"
        //    : $"Wiek książki {DateTime.Now.Year - find.ReleaseDate.Year}";
        //}
        ////Jednym z problemów takiej metody jest brak możliwości testowania.Test uruchomiony w bieżącym
        ////roku zwróci inną wartość niż też uruchomiony w przyszłym roku(wiek książki się zwiększy).
        ////Bieżąca data powinna być zależnością kontrolera, dlatego korzystamy z IOC i dodajemy pole typu
        ////IClockProvider w kontrolerze.
        
        public string Age(int? id)
        {
            var find = _bookService.FindBy(id);
            return find is null
            ? "Brak takiej ksiązki"
            : $"Wiek książki {_clock.Now().Year - find.ReleaseDate.Year}";
        }
    }
}
