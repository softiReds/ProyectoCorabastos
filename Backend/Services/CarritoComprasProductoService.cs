using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class CarritoComprasProductoService : ICarritoComprasProductoService
{
    private readonly IRepository<CarritoComprasProducto> _carritoComprasProductoRepository;

    public CarritoComprasProductoService(IRepository<CarritoComprasProducto> carritoComprasProductoRepository)
    {
        _carritoComprasProductoRepository = carritoComprasProductoRepository;
    }

    public Task<List<CarritoComprasProducto>> Get() => _carritoComprasProductoRepository.Get();

    public Task<CarritoComprasProducto> GetById(Guid carritoComprasId, Guid productoId)
        => _carritoComprasProductoRepository.GetById(carritoComprasId, productoId);

    public async Task<CarritoComprasProducto> Post(CarritoComprasProducto carritoComprasProducto)
    {
        await _carritoComprasProductoRepository.Create(carritoComprasProducto);
        await _carritoComprasProductoRepository.SaveChanges();
        return carritoComprasProducto;
    }

    public async Task<CarritoComprasProducto> Put(CarritoComprasProducto carritoComprasProducto)
    {
        _carritoComprasProductoRepository.Update(carritoComprasProducto);
        await _carritoComprasProductoRepository.SaveChanges();
        return carritoComprasProducto;
    }

    public async Task<CarritoComprasProducto> Delete(Guid carritoComprasId, Guid productoId)
    {
        var carritoComprasProducto = await _carritoComprasProductoRepository.GetById(carritoComprasId, productoId);
        _carritoComprasProductoRepository.Delete(carritoComprasId, productoId);
        await _carritoComprasProductoRepository.SaveChanges();
        return carritoComprasProducto;
    }
}