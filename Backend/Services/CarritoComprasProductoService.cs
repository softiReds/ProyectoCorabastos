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

    public void Post(CarritoComprasProducto carritoComprasProducto)
    {
        _carritoComprasProductoRepository.Create(carritoComprasProducto);
        _carritoComprasProductoRepository.SaveChanges();
    }

    public void Put(CarritoComprasProducto carritoComprasProducto)
    {
        _carritoComprasProductoRepository.Update(carritoComprasProducto);
        _carritoComprasProductoRepository.SaveChanges();
    }

    public void Delete(Guid carritoComprasId, Guid productoId)
    {
        _carritoComprasProductoRepository.Delete(carritoComprasId, productoId);
        _carritoComprasProductoRepository.SaveChanges();
    }
}