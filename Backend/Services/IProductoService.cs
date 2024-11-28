using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IProductoService
{
    Task<List<Producto>> Get();
    Task<Producto> GetById(Guid id);
    Task<Producto> Post(Producto producto);
    Task<Producto> Put(Producto producto);
    Task<Producto> Delete(Guid id);
}