using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IInventarioProductoService
{
    Task<List<InventarioProducto>> Get();
    Task<InventarioProducto> GetById(Guid inventarioId, Guid productoId);
    Task Post(InventarioProducto inventarioProducto);
    void Put(InventarioProducto inventarioProducto);
    void Delete(Guid inventarioId, Guid productoId);
}