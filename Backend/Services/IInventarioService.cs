using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IInventarioService
{
    Task<List<Inventario>> Get();
    Task<Inventario> GetById(Guid id);
    Task Post(Inventario inventario);
    void Put(Inventario inventario);
    void Delete(Guid id);
}