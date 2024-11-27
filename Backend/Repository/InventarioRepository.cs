using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class InventarioRepository
{
    private readonly CorabastosContext _dbContext;

    public InventarioRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Inventario>> Get() => await _dbContext.Inventarios.ToListAsync();

    public async Task<Inventario> GetById(Guid id) => await _dbContext.Inventarios.FindAsync(id);
    
    public async Task Create(Inventario entidad) => await _dbContext.Inventarios.AddAsync(entidad);

    public void Update(Inventario entidad)
    {
        _dbContext.Inventarios.Attach(entidad);
        _dbContext.Inventarios.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var inventario = await GetById(id);
        _dbContext.Inventarios.Remove(inventario);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}