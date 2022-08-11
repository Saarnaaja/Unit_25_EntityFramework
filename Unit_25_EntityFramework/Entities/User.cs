namespace Unit_25_EntityFramework.Entities;
public class User : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Book> BooksOnHand { set; get; }

    public User()
    {
        BooksOnHand = new List<Book>();
    }
}
