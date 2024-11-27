using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ITipoUsuarioService
{
    Task<List<TipoUsuario>> Get();
    Task<TipoUsuario> GetById(Guid id);
    Task Post(TipoUsuario ciudad);
    void Put(TipoUsuario ciudad);
    void Delete(Guid id);
}