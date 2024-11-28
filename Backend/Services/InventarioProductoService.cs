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

    public async Task<InventarioProducto> Post(InventarioProducto inventarioProducto)
    {
        await _inventarioProductoRepository.Create(inventarioProducto);
        await _inventarioProductoRepository.SaveChanges();
        return inventarioProducto;
    }

    public async Task<InventarioProducto> Put(InventarioProducto inventarioProducto)
    {
        _inventarioProductoRepository.Update(inventarioProducto);
        await _inventarioProductoRepository.SaveChanges();
        return inventarioProducto;
    }

    public async Task<InventarioProducto> Delete(Guid inventarioId, Guid productoId)
    {
        var inventarioProducto = await _inventarioProductoRepository.GetById(inventarioId, productoId);
        _inventarioProductoRepository.Delete(inventarioId, productoId);
        await _inventarioProductoRepository.SaveChanges();
        return inventarioProducto;
    }
}