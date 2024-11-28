using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    Task<CarritoCompras> Post(CarritoCompras carritoCompras);
    Task<CarritoCompras> Put(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto);
    Task<CarritoCompras> Delete(Guid id);

    int CalcularTotalCarritoCompras(int totalCarrito, Guid idProducto, int cantidadProducto);
}