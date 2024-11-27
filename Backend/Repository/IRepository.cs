namespace CorabastosAPI.Repositories;

public interface IRepository <TEntity>
{
    Task<List<TEntity>> Get();
    Task<TEntity> GetById(Guid id);
    Task Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(Guid id);
    Task SaveChanges();
}