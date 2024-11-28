using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class CarritoComprasService : ICarritoComprasService
{
    private readonly IRepository<CarritoCompras> _carritoComprasRepository;

    public CarritoComprasService(IRepository<CarritoCompras> carritoComprasRepository)
    {
        _carritoComprasRepository = carritoComprasRepository;
    }

    public Task<List<CarritoCompras>> Get() => _carritoComprasRepository.Get();

    public Task<CarritoCompras> GetById(Guid id) => _carritoComprasRepository.GetById(id);

    public void Post(CarritoCompras carritoCompras)
    {
        _carritoComprasRepository.Create(carritoCompras);
        _carritoComprasRepository.SaveChanges();
    }

    public void Put(CarritoCompras carritoCompras)
    {
        _carritoComprasRepository.Update(carritoCompras);
        _carritoComprasRepository.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _carritoComprasRepository.Delete(id);
        _carritoComprasRepository.SaveChanges();
    }
}