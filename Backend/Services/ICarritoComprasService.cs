using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    Task<CarritoCompras> Post(CarritoCompras carritoCompras);
    Task<CarritoCompras> Put(CarritoCompras carritoCompras);
    Task<CarritoCompras> Delete(Guid id);
}