using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IProductoService
{
    Task<List<Producto>> Get();
    Task<Producto> GetById(Guid id);
    Task Post(Producto producto);
    void Put(Producto producto);
    void Delete(Guid id);
}