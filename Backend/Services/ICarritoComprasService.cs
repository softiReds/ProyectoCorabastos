using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    Task<CarritoCompras> Post(CarritoCompras carritoCompras);
    Task<CarritoCompras> Put(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto, bool agregarProducto);
    Task<CarritoCompras> Delete(Guid id);

    int AgregarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProducto);
    int QuitarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProducto);
}