namespace Unit_25_EntityFramework.Entities;
public class Genre : IEntity
{
    public int Id { set; get; }
    public string Name { set; get; }
    public List<Book> Books { set; get; }

    public Genre()
    {
        Books = new List<Book>();
    }
}
