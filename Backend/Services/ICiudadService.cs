using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICiudadService
{
    Task<List<Ciudad>> Get();
    Task<Ciudad> GetById(Guid id);
    Task<Ciudad> Post(Ciudad ciudad);
    Task<Ciudad> Put(Ciudad ciudad);
    Task<Ciudad> Delete(Guid id);
}