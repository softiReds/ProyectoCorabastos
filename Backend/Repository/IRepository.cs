namespace CorabastosAPI.Repositories;

public interface IRepository <TEntity>
{
    Task<List<TEntity>> Get();
    Task<TEntity> GetById(Guid id);
    Task<TEntity> GetById(Guid id1, Guid id2);
    Task Create(TEntity entidad);
    void Update(TEntity entidad);
    Task Delete(Guid id);
    Task Delete(Guid id1, Guid id2);
    Task SaveChanges();
}