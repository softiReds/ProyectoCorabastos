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

    public void Post(Ciudad ciudad)
    {
        _ciudadRepository.Create(ciudad);
        _ciudadRepository.SaveChanges();
    }

    public void Put(Ciudad ciudad)
    {
        _ciudadRepository.Update(ciudad);
        _ciudadRepository.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _ciudadRepository.Delete(id);
        _ciudadRepository.SaveChanges();
    }
}