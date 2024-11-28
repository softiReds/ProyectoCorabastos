using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IUsuarioService
{
    Task<List<Usuario>> Get();
    Task<Usuario> GetById(Guid id);
    Task<Usuario> Post(Usuario usuario);
    Task<Usuario> Put(Usuario usuario);
    Task<Usuario> Delete(Guid id);
}