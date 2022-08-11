using Unit_25_EntityFramework.Entities;

namespace Unit_25_EntityFramework.Repositories;
public interface IRepository<TEntity> where TEntity : IEntity
{
    TEntity? GetById(int id);
    List<TEntity> GetList();
    void AddToDB(TEntity entity);
    void RemoveFromDB(TEntity entity);
}
