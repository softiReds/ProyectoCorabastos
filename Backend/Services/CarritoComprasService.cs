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

    public async Task<CarritoCompras> Post(CarritoCompras carritoCompras)
    {
        await _carritoComprasRepository.Create(carritoCompras);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public async Task<CarritoCompras> Put(CarritoCompras carritoCompras)
    {
        _carritoComprasRepository.Update(carritoCompras);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public async Task<CarritoCompras> Delete(Guid id)
    {
        var carritoCompras = await _carritoComprasRepository.GetById(id);
        _carritoComprasRepository.Delete(id);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }
}