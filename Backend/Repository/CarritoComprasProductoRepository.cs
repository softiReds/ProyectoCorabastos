using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class CarritoComprasProductoRepository : IRepository<CarritoComprasProducto>
{
    private CorabastosContext _dbContext;

    public CarritoComprasProductoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarritoComprasProducto>> Get() => await _dbContext.CarritoComprasProductos.ToListAsync();

    public Task<CarritoComprasProducto> GetById(Guid id)
        => throw new NotSupportedException("Use el método GetById(Guid carritoComprasId, Guid productoId).");

    public async Task<CarritoComprasProducto> GetById(Guid carritoComprasId, Guid productoId) =>
        await _dbContext.CarritoComprasProductos.FindAsync(new object[] { carritoComprasId, productoId });

    public async Task Create(CarritoComprasProducto entidad) => await _dbContext.CarritoComprasProductos.AddAsync(entidad);

    public void Update(CarritoComprasProducto entidad)
    {
        _dbContext.CarritoComprasProductos.Attach(entidad);
        _dbContext.CarritoComprasProductos.Entry(entidad).State = EntityState.Modified;
    }

    public void Delete(Guid id) => throw new NotSupportedException("Use el método Delete(Guid carritoComprasId, Guid productoId).");

    public async void Delete(Guid carritoComprasId, Guid productoId)
    {
        var carritoComprasProducto = await GetById(carritoComprasId, productoId);
        _dbContext.CarritoComprasProductos.Remove(carritoComprasProducto);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}