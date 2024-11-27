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

    public async Task Create(Ciudad entity)=> await _dbContext.Ciudades.AddAsync(entity);

    public void Update(Ciudad entity)
    {
        _dbContext.Ciudades.Attach(entity);
        _dbContext.Ciudades.Entry(entity).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var ciudad = await GetById(id);
        _dbContext.Ciudades.Remove(ciudad);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}