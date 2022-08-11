using Unit_25_EntityFramework.Entities;

namespace Unit_25_EntityFramework.Repositories;
public class GenreRepository : IRepository<Genre>
{
    private AppContext _context;
    public GenreRepository(AppContext context)
    {
        _context = context;
    }
    public void AddToDB(Genre entity)
    {
        _context.Genres.Add(entity);
        _context.SaveChanges();
    }

    public Genre? GetById(int genreId)
    {
        return _context.Genres.FirstOrDefault(x => x.Id == genreId);
    }

    public List<Genre> GetList()
    {
        return _context.Genres.ToList();
    }

    //Задание 25.5.4 п.3
    public int GetBookCountByGenre(int genreId)
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Id == genreId);
        if (genre == null) return 0;
        return genre.Books.Count;
    }

    //Задание 25.5.4 п.1
    public List<Book>? GetBooksBeetweenYears(int genreId, int yearStart, int yearEnd)
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Id == genreId);
        if (genre == null) return null;
        return genre.Books.Where(x => x.Year >= yearStart && x.Year <= yearEnd).ToList();
    }

    public void RemoveFromDB(Genre entity)
    {
        _context.Genres.Remove(entity);
        _context.SaveChanges();
    }
}
