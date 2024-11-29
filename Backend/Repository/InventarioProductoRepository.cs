using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories
{
    public class InventarioProductoRepository : IRepository<InventarioProducto>
    {
        private readonly CorabastosContext _dbContext;

        public InventarioProductoRepository(CorabastosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InventarioProducto>> Get() => await _dbContext.InventarioProductos.ToListAsync();

        public Task<InventarioProducto> GetById(Guid id)
            => throw new NotSupportedException("Use el método GetById(Guid inventarioId, Guid productoId).");

        public async Task<InventarioProducto> GetById(Guid inventarioId, Guid productoId) =>
            await _dbContext.InventarioProductos.FindAsync(new object[] { inventarioId, productoId });

        public async Task Create(InventarioProducto entidad) => await _dbContext.InventarioProductos.AddAsync(entidad);

        public void Update(InventarioProducto entidad)
        {
            _dbContext.InventarioProductos.Attach(entidad);
            _dbContext.InventarioProductos.Entry(entidad).State = EntityState.Modified;
        }

        public Task Delete(Guid id) => throw new NotSupportedException("Use el método Delete(Guid inventarioId, Guid productoId).");

        public async Task Delete(Guid inventarioId, Guid productoId)
        {
            var inventarioProducto = await GetById(inventarioId, productoId);
            _dbContext.InventarioProductos.Remove(inventarioProducto);
        }

        public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
    }
}