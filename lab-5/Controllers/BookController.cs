using lab_5.Models;
using Microsoft.AspNetCore.Mvc;
using wsei_asp_net_lab.Models;

namespace lab_5.Controllers;

public class BookController : Controller
{

    private static AppDbContext _context = new AppDbContext();
    // GET
    public IActionResult Index()
    {
        return View(_context.Books.ToList());
    }

    public IActionResult Edit([FromRoute] int id)
    {
        Book? foundBook = _context.Books.Find(id);
        if (foundBook is not null)
        {
            return View(foundBook);
        }

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Edit([FromForm] Book book)
    {
        if (ModelState.IsValid)
        {
            Book? foundBook = _context.Books.Find(book.Id);
            if (foundBook is not null)
            {
                foundBook.Title = book.Title;
                foundBook.ReleaseDate = book.ReleaseDate;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        return View();
    }
    
    [HttpPost]
    public IActionResult Create([FromForm] Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Delete([FromRoute] int id)
    {
        Book? foundBook = _context.Books.Find(id);
        _context.Books.Remove(foundBook);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details([FromRoute] int id)
    {
        Book? foundBook = _context.Books.Find(id);
        return foundBook is not null ? View(foundBook) : RedirectToAction(nameof(Index));
    }
}