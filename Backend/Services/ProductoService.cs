using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class ProductoService : IProductoService
{
    private readonly IRepository<Producto> _productoRepository;

    public ProductoService(IRepository<Producto> productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public Task<List<Producto>> Get() => _productoRepository.Get();

    public Task<Producto> GetById(Guid id) => _productoRepository.GetById(id);

    public async Task<Producto> Post(Producto producto)
    {
        await _productoRepository.Create(producto);
        await _productoRepository.SaveChanges();
        return producto;
    }

    public async Task<Producto> Put(Producto producto)
    {
        _productoRepository.Update(producto);
        await _productoRepository.SaveChanges();
        return producto;
    }

    public async Task<Producto> Delete(Guid id)
    {
        var producto = await _productoRepository.GetById(id);
        _productoRepository.Delete(id);
        await _productoRepository.SaveChanges();
        return producto;
    }
}