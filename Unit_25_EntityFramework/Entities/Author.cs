namespace Unit_25_EntityFramework.Entities;
public class Author : IEntity
{
    public int Id { get; set; }
    public string Name { set; get; }
    public List<Book> Books { set; get; }

    public Author()
    {
        Books = new List<Book>();
    }
}
