using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICarritoComprasService
{
    Task<List<CarritoCompras>> Get();
    Task<CarritoCompras> GetById(Guid id);
    Task Post(CarritoCompras carritoCompras);
    void Put(CarritoCompras carritoCompras);
    void Delete(Guid id);
}