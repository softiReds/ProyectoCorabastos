using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IUsuarioService
{
    Task<List<Usuario>> Get();
    Task<Usuario> GetById(Guid id);
    Task Post(Usuario ciudad);
    void Put(Usuario ciudad);
    void Delete(Guid id);
}