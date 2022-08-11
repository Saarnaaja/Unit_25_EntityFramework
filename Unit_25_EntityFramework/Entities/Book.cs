namespace Unit_25_EntityFramework.Entities;
public class Book : IEntity
{
    public int Id { set; get; }
    public string Title { get; set; }
    public int Year { set; get; }
    public Author Author { set; get; }
    public Genre Genge { set; get; }
    public User? User { set; get; }
}
