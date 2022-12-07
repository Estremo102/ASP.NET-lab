using Microsoft.EntityFrameworkCore;

namespace lab_8.Models;

public class BookRepositoryEF: IBookService
{
    private readonly AppDbContext _context;

    public BookRepositoryEF(AppDbContext context)
    {
        _context = context;
    }

    public int Save(Book book)
    {
        try
        {
            var entityEntry = _context.Books.Add(book);
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }
        catch
        {
            return -1;
        }
    }
    public bool Delete(int? id)
    {
        if (id is null)
        {
            return false;
        }
        
        var find = _context.Books.Find(id);
        if (find is not null)
        {
            _context.Books.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Update(Book book)
    {
        try
        {
            var find = _context.Books.Find(book.Id);
            if (find is not null)
            {
                find.Title = book.Title;
                find.ReleaseDate = book.ReleaseDate;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        catch(DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public Book? FindBy(int? id)
    {
        return id is null ? null : _context.Books.Find(id);
    }

    public ICollection<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public ICollection<Book> FindByAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public ICollection<Book> FindPage(int page = 0, int size = 10)
    {
        return _context.Books.Skip(page * size).Take(page).ToHashSet();
    }

    public (string Error, int Age) BookAge(int? id)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}