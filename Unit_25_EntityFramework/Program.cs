using (var db = new Unit_25_EntityFramework.AppContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}