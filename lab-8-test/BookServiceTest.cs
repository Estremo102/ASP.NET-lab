using lab_8.Models;
namespace lab_8_test
{
    public class BookServiceTest : IBookService
    {
        private Dictionary<int, Book> _books;
        private int index;
        public BookServiceTest()
        {
            _books = new Dictionary<int, Book>();
            index = 1;
        }
        public (string Error, int Age) BookAge(int? id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int? id) => _books.Remove(id ?? 0);

        public ICollection<Book> FindAll() => _books.Values;

        public Book? FindBy(int? id)
        {
            if (id != null && _books.ContainsKey((int)id))
            {
                return _books[(int)id];
            }
            return null;
        }
        public ICollection<Book> FindByAuthor(Author author)
        {
            throw new NotImplementedException();
        }
        public ICollection<Book> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }
        public int Save(Book book)
        {
            book.Id = index++;
            _books.Add(book.Id, book);
            return book.Id;
        }
        public bool Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}