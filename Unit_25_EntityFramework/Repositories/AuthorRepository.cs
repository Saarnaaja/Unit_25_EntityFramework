using Unit_25_EntityFramework.Entities;

namespace Unit_25_EntityFramework.Repositories;
public class AuthorRepository : IRepository<Author>
{
    private AppContext _context;
    public AuthorRepository(AppContext context)
    {
        _context = context;
    }
    public void AddToDB(Author entity)
    {
        _context.Authors.Add(entity);
        _context.SaveChanges();
    }

    public Author? GetById(int authorId)
    {
        return _context.Authors.FirstOrDefault(x => x.Id == authorId);
    }

    public List<Author> GetList()
    {
        return _context.Authors.ToList();
    }

    //Задание 25.5.4 п.2
    public int GetBookCount(int authorId)
    {
        var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
        if (author == null) return 0;
        return author.Books.Count;
    }

    public void RemoveFromDB(Author entity)
    {
        _context.Authors.Remove(entity);
        _context.SaveChanges();
    }

    //Задание 25.5.4 п.4
    public bool FindBook(int authorId, string bookTitle)
    {
        var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
        if (author == null) return false;
        return author.Books.FirstOrDefault(x => x.Title.ToUpper() == bookTitle.ToUpper()) != null;
    }
}
