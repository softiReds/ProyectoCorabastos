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

    public Task<CarritoCompras> GetById(Guid id1, Guid id2) => throw new NotSupportedException("Use el método GetById(Guid id).");


    public async Task Create(CarritoCompras entidad) => await _dbContext.CarritosCompras.AddAsync(entidad);

    public void Update(CarritoCompras entidad)
    {
        _dbContext.CarritosCompras.Attach(entidad);
        _dbContext.CarritosCompras.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var carritoCompras = await GetById(id);
        _dbContext.CarritosCompras.Remove(carritoCompras);
    }

    public void Delete(Guid id1, Guid id2) => throw new NotSupportedException("Use el método Delete(Guid id).");

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}