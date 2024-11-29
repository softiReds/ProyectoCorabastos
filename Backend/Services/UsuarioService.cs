using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IRepository<Usuario> _usuarioRepository;

    public UsuarioService(IRepository<Usuario> usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<List<Usuario>> Get() => _usuarioRepository.Get();

    public Task<Usuario> GetById(Guid id) => _usuarioRepository.GetById(id);

    public async Task<Usuario> Post(Usuario usuario)
    {
        await _usuarioRepository.Create(usuario);
        await _usuarioRepository.SaveChanges();
        return usuario;
    }

    public async Task<Usuario> Put(Usuario usuario)
    {
        _usuarioRepository.Update(usuario);
        await _usuarioRepository.SaveChanges();
        return usuario;
    }

    public async Task<Usuario> Delete(Guid id)
    {
        var usuario = await _usuarioRepository.GetById(id);
        _usuarioRepository.Delete(id);
        await _usuarioRepository.SaveChanges();
        return usuario;
    }
}