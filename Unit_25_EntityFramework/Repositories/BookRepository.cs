using Unit_25_EntityFramework.Entities;

namespace Unit_25_EntityFramework.Repositories;
public class BookRepository : IRepository<Book>
{
    private AppContext _context;
    public BookRepository(AppContext context)
    {
        _context = context;
    }

    public void AddToDB(Book entity)
    {
        _context.Books.Add(entity);
        _context.SaveChanges();
    }

    public Book? GetById(int bookId)
    {
        return _context.Books.FirstOrDefault(x => x.Id == bookId);
    }

    public List<Book> GetList()
    {
        return _context.Books.ToList();
    }

    //Задание 25.5.4 п.9
    public List<Book> GetSortedByYearList()
    {
        return _context.Books.OrderByDescending(x => x.Year).ToList();
    }

    //Задание 25.5.4 п.8
    public List<Book> GetSortedByTitleList()
    {
        return _context.Books.OrderBy(x => x.Title).ToList();
    }

    //Задание 25.5.4 п.7
    public Book? GetLastPublished()
    {
        return _context.Books.OrderByDescending(x => x.Year).FirstOrDefault();
    }

    //Задание 25.5.4 п.5
    public bool BookOnHand(int bookId)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
        if (book == null) return false;
        return book.User != null;
    }

    //Задание 25.5.4 п.3
    public int GetBookCountByGenre(int genreId)
    {
        return _context.Books.Count(x => x.Genge.Id == genreId);
    }

    public void RemoveFromDB(Book entity)
    {
        _context.Books.Remove(entity);
        _context.SaveChanges();
    }

    public void UpdateBookYear(int bookId, int newYear)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
        if (book == null) return;
        book.Year = newYear;
        _context.SaveChanges();
    }
}
