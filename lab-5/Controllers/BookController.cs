using lab_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wsei_asp_net_lab.Models;

namespace lab_5.Controllers;

public class BookController : Controller
{

    private static AppDbContext _context = new AppDbContext();
    // GET
    public IActionResult Index()
    {
        return View(_context.Books.Include(b=>b.Authors).ToList());
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
    public IActionResult Create([FromForm] BookViewModel book)
    {
        if (ModelState.IsValid)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Created = DateTime.Now,
                ReleaseDate = book.ReleaseDate
            };
            foreach (var strId in book.AuthorsId)
            {
                if (int.TryParse(strId, out int id))
                {
                    newBook.Authors.Add(_context.Authors.Find(id));
                }
            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        book.Authors = GetAuthors();
        return View(book);
    }

    public IActionResult Create()
    {
        BookViewModel model = new BookViewModel();
        model.Authors = GetAuthors();
        return View(model);
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

    private List<SelectListItem> GetAuthors()
    {
        return _context
        .Authors
        .Select(a => new SelectListItem()
        {
            Value = a.Id.ToString(),
            Text = $"{a.FirstName} {a.LastName}"
        })
        .ToList();
    }
}