using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class CiudadRepository : IRepository<Ciudad>
{
    private CorabastosContext _dbContext;

    public CiudadRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Ciudad>> Get() => await _dbContext.Ciudades.ToListAsync();

    public async Task<Ciudad> GetById(Guid id) => await _dbContext.Ciudades.FindAsync(id);

    public Task<Ciudad> GetById(Guid id1, Guid id2)
        => throw new NotSupportedException("Use el método GetById(Guid id).");

    public async Task Create(Ciudad entidad) => await _dbContext.Ciudades.AddAsync(entidad);

    public void Update(Ciudad entidad)
    {
        _dbContext.Ciudades.Attach(entidad);
        _dbContext.Ciudades.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var ciudad = await GetById(id);
        _dbContext.Ciudades.Remove(ciudad);
    }

    public void Delete(Guid id1, Guid id2)
        => throw new NotSupportedException("Use el método Delete(Guid id).");

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}