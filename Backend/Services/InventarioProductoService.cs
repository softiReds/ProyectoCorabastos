using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class InventarioProductoService : IInventarioProductoService
{
    private readonly IRepository<InventarioProducto> _inventarioProductoRepository;

    public InventarioProductoService(IRepository<InventarioProducto> inventarioProductoRepository)
    {
        _inventarioProductoRepository = inventarioProductoRepository;
    }

    public Task<List<InventarioProducto>> Get() => _inventarioProductoRepository.Get();

    public Task<InventarioProducto> GetById(Guid inventarioId, Guid productoId)
        => _inventarioProductoRepository.GetById(inventarioId, productoId);

    public Task Post(InventarioProducto inventarioProducto)
    {
        _inventarioProductoRepository.Create(inventarioProducto);
        return _inventarioProductoRepository.SaveChanges();
    }

    public void Put(InventarioProducto inventarioProducto)
    {
        _inventarioProductoRepository.Update(inventarioProducto);
        _inventarioProductoRepository.SaveChanges();
    }

    public void Delete(Guid inventarioId, Guid productoId)
    {
        _inventarioProductoRepository.Delete(inventarioId, productoId);
        _inventarioProductoRepository.SaveChanges();
    }
}