using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasProductoService
{
    Task<List<CarritoComprasProducto>> Get();
    Task<CarritoComprasProducto> GetById(Guid carritoComprasId, Guid productoId);
    Task<CarritoComprasProducto> Post(CarritoComprasProducto carritoComprasProducto);
    Task<CarritoComprasProducto> Put(CarritoComprasProducto carritoComprasProducto);
    Task<CarritoComprasProducto> Delete(Guid carritoComprasId, Guid productoId);
}