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

    public async Task<Inventario> Post(Inventario inventario)
    {
        await _inventarioRepository.Create(inventario);
        await _inventarioRepository.SaveChanges();
        return inventario;
    }

    public async Task<Inventario> Put(Inventario inventario)
    {
        _inventarioRepository.Update(inventario);
        await _inventarioRepository.SaveChanges();
        return inventario;
    }

    public async Task<Inventario> Delete(Guid id)
    {
        var inventario = await _inventarioRepository.GetById(id);
        _inventarioRepository.Delete(id);
        await _inventarioRepository.SaveChanges();
        return inventario;
    }
}