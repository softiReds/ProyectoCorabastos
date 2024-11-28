using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IInventarioService
{
    Task<List<Inventario>> Get();
    Task<Inventario> GetById(Guid id);
    Task<Inventario> Post(Inventario inventario);
    Task<Inventario> Put(Inventario inventario);
    Task<Inventario> Delete(Guid id);
}