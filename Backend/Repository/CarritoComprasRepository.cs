using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class CarritoComprasRepository : IRepository<CarritoCompras>
{
    private CorabastosContext _dbContext;

    public CarritoComprasRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarritoCompras>> Get() => await _dbContext.CarritosCompras.ToListAsync();

    public async Task<CarritoCompras> GetById(Guid id) => await _dbContext.CarritosCompras.FindAsync(id);

    public async Task Create(CarritoCompras entity) => await _dbContext.CarritosCompras.AddAsync(entity);

    public void Update(CarritoCompras entity)
    {
        _dbContext.CarritosCompras.Attach(entity);
        _dbContext.CarritosCompras.Entry(entity).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var carritoCompras = await GetById(id);
        _dbContext.CarritosCompras.Remove(carritoCompras);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}