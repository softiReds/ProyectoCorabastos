using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class InventarioService : IInventarioService
{
    private readonly IRepository<Inventario> _inventarioRepository;

    public InventarioService(IRepository<Inventario> inventarioRepository)
    {
        _inventarioRepository = inventarioRepository;
    }

    public Task<List<Inventario>> Get() => _inventarioRepository.Get();

    public Task<Inventario> GetById(Guid id) => _inventarioRepository.GetById(id);

    public Task Post(Inventario inventario) => _inventarioRepository.Create(inventario);

    public void Put(Inventario inventario) => _inventarioRepository.Update(inventario);

    public void Delete(Guid id) => _inventarioRepository.Delete(id);
}