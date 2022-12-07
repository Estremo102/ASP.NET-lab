using Microsoft.AspNetCore.Mvc;
using lab_8.Models;

namespace lab_8.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IClockProvider _clock;
        public BookController(AppDbContext context, IBookService bookService, IClockProvider clock)
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
            return book is null ? NotFound(): View(book);
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

        public string Age(int? id)
        {
            var find = _bookService.FindBy(id);
            return find is null ? "Brak takiej ksiązki" : $"Wiek książki {_clock.Now().Year - find.ReleaseDate.Year}";
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Title,ReleaseDate,Created")] Book book)
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
            return book is null ? NotFound(): View(book);
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
    }
}