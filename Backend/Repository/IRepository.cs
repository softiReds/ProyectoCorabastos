namespace CorabastosAPI.Repositories;

public interface IRepository <TEntity>
{
    Task<List<TEntity>> Get();
    Task<TEntity> GetById(Guid id);
    Task Create(TEntity entidad);
    void Update(TEntity entidad);
    void Delete(Guid id);
    Task SaveChanges();
}