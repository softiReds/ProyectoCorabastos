using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IInventarioProductoService
{
    Task<List<InventarioProducto>> Get();
    Task<InventarioProducto> GetById(Guid inventarioId, Guid productoId);
    Task<InventarioProducto> Post(InventarioProducto inventarioProducto);
    Task<InventarioProducto> Put(InventarioProducto inventarioProducto);
    Task<InventarioProducto> Delete(Guid inventarioId, Guid productoId);
}