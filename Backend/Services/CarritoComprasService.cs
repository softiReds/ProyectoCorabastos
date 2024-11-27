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

    public Task Post(CarritoCompras carritoCompras) => _carritoComprasRepository.Create(carritoCompras);

    public void Put(CarritoCompras carritoCompras) => _carritoComprasRepository.Update(carritoCompras);

    public void Delete(Guid id) => _carritoComprasRepository.Delete(id);
}