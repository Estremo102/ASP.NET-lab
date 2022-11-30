using Microsoft.EntityFrameworkCore;

namespace lab_6.Models
{
    public class BookServiceEF : IBookService           // Klasa implementuje interfejs
    {
        private readonly AppDbContext _context;         //Pole z kontekstem bazy
        public BookServiceEF(AppDbContext context)      //Konstruktor z wstrzykiwanym kontekstem bazy
        {
            _context = context;
        }

        public int Save(Book book)                      //Implementacja metody Save, która zwraca
        {                                               //id zapisanej w bazie encji
            var entityEntry = _context.Books.Add(book); 
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }

        public bool Delete(int? id)                     //Implementacja metody Delete zwracająca
        {                                               //true, jeśli obiekt został usunięty.
            if (id is null) return false;               //Wartość false sygnalizuje próbę usunięcia
            var find = _context.Books.Find(id);         //nieistniejącej książki lub przekazanie
            if(find is null) return false;              //id z null
            _context.Books.Remove(find);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Book book)
        {
            try
            {
                var find = _context.Books.Find(book.Id);
                if(find is null) return false;
                find.Title = book.Title;
                find.ReleaseDate= book.ReleaseDate;
                _context.SaveChanges();
                return true;
            }
            catch(DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public Book? FindBy(int? id) =>
            _context.Books.Where(e => e.Id == id).FirstOrDefault();

        public ICollection<Book> FindAll() => 
            _context.Books.Include(e => e.Authors).ToList();

        public ICollection<Book> FindByAuthor(Author author) => 
            FindAll().Where(e => e.Authors.Contains(author)).ToList();

        public ICollection<Book> FindPage(int page = 0, int size = 10) =>
            _context.Books.Skip(page*size).Take(page).ToHashSet();
    }
}
