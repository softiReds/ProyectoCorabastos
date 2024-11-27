using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class ProductoRepository : IRepository<Producto>
{
    private CorabastosContext _dbContext;

    public ProductoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Producto>> Get() => await _dbContext.Productos.ToListAsync();

    public async Task<Producto> GetById(Guid id) => await _dbContext.Productos.FindAsync(id);

    public async Task Create(Producto entidad) => await _dbContext.Productos.AddAsync(entidad);

    public void Update(Producto entidad)
    {
        _dbContext.Productos.Attach(entidad);
        _dbContext.Productos.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var producto = await GetById(id);
        _dbContext.Productos.Remove(producto);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}