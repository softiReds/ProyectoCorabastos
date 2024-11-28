using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    void Post(CarritoCompras carritoCompras);
    void Put(CarritoCompras carritoCompras);
    void Delete(Guid id);
}