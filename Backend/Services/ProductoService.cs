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

    public Task Post(Producto producto) => _productoRepository.Create(producto);

    public void Put(Producto producto) => _productoRepository.Update(producto);

    public void Delete(Guid id) => _productoRepository.Delete(id);
}