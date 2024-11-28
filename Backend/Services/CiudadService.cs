using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class CiudadService : ICiudadService
{
    private readonly IRepository<Ciudad> _ciudadRepository;

    public CiudadService(IRepository<Ciudad> ciudadRepository)
    {
        _ciudadRepository = ciudadRepository;
    }

    public Task<List<Ciudad>> Get() => _ciudadRepository.Get();

    public Task<Ciudad> GetById(Guid id) => _ciudadRepository.GetById(id);

    public async Task<Ciudad> Post(Ciudad ciudad)
    {
        await _ciudadRepository.Create(ciudad);
        await _ciudadRepository.SaveChanges();
        return ciudad;
    }

    public async Task<Ciudad> Put(Ciudad ciudad)
    {
        _ciudadRepository.Update(ciudad);
        await _ciudadRepository.SaveChanges();
        return ciudad;
    }

    public async Task<Ciudad> Delete(Guid id)
    {
        var ciudad = await _ciudadRepository.GetById(id);
        _ciudadRepository.Delete(id);
        await _ciudadRepository.SaveChanges();
        return ciudad;
    }
}