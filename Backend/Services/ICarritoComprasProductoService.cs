using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasProductoService
{
    Task<List<CarritoComprasProducto>> Get();
    Task<CarritoComprasProducto> GetById(Guid carritoComprasId, Guid productoId);
    Task Post(CarritoComprasProducto carritoComprasProducto);
    void Put(CarritoComprasProducto carritoComprasProducto);
    void Delete(Guid carritoComprasId, Guid productoId);
}