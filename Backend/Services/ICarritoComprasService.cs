using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    Task<CarritoCompras> Post(CarritoCompras carritoCompras);
    Task<CarritoCompras> AgregarQuitarProducto(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto, bool agregarProducto);
    Task<CarritoCompras> Put(CarritoCompras carritoCompras);
    Task<CarritoCompras> Delete(Guid id);

    (int totalCarrito, int cantidadProducto) AgregarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProducto, int cantidadProductoDb);
    (int totalCarrito, int cantidadProducto) QuitarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProductoEliminado,
        int cantidadProducto);
}