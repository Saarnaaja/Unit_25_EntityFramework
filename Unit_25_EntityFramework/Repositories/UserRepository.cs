using Unit_25_EntityFramework.Entities;

namespace Unit_25_EntityFramework.Repositories;
public class UserRepository : IRepository<User>
{
    private AppContext _context;
    public UserRepository(AppContext context)
    {
        _context = context;
    }

    public void AddToDB(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public User? GetById(int userId)
    {
        return _context.Users.FirstOrDefault(x => x.Id == userId);
    }

    public List<User> GetList()
    {
        return _context.Users.ToList();
    }

    public void RemoveFromDB(User entity)
    {
        _context.Users.Remove(entity);
        _context.SaveChanges();
    }

    //Задание 25.5.4 п.6
    public int GetBooksOnHand(int userId)
    {
        var user = _context.Users.FirstOrDefault((x) => x.Id == userId);
        if (user != null)
            return user.BooksOnHand.Count;
        return 0;
    }

    public void UpdateUserName(int userId, string newName)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null) return;
        user.Name = newName;
        _context.SaveChanges();
    }
}
