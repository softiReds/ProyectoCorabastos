using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ICiudadService
{
    Task<List<Ciudad>> Get();
    Task<Ciudad> GetById(Guid id);
    Task Post(Ciudad ciudad);
    void Put(Ciudad ciudad);
    void Delete(Guid id);
}