using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface ITipoUsuarioService
{
    Task<List<TipoUsuario>> Get();
    Task<TipoUsuario> GetById(Guid id);
    Task<TipoUsuario> Post(TipoUsuario ciudad);
    Task<TipoUsuario> Put(TipoUsuario ciudad);
    Task<TipoUsuario> Delete(Guid id);
}