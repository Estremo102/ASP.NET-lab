namespace lab_8.Models;

public interface IBookService
{
    public int Save(Book book);

    public bool Delete(int? id);

    public bool Update(Book book);

    public Book? FindBy(int? id);

    public ICollection<Book> FindAll();

    public ICollection<Book> FindByAuthor(Author author);

    public ICollection<Book> FindPage(int page, int size);
    
    public (string Error, int Age) BookAge(int? id);
}