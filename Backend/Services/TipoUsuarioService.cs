using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class TipoUsuarioService : ITipoUsuarioService
{
    private readonly IRepository<TipoUsuario> _tipoUsuarioRepository;

    public TipoUsuarioService(IRepository<TipoUsuario> tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    public Task<List<TipoUsuario>> Get() => _tipoUsuarioRepository.Get();

    public Task<TipoUsuario> GetById(Guid id) => _tipoUsuarioRepository.GetById(id);

    public async Task<TipoUsuario> Post(TipoUsuario tipoUsuario)
    { 
        await _tipoUsuarioRepository.Create(tipoUsuario);
        await _tipoUsuarioRepository.SaveChanges();
        return tipoUsuario;
    }

    public async Task<TipoUsuario> Put(TipoUsuario tipoUsuario)
    {
        _tipoUsuarioRepository.Update(tipoUsuario);
        await _tipoUsuarioRepository.SaveChanges();
        return tipoUsuario;
    }

    public async Task<TipoUsuario> Delete(Guid id)
    {
        var tipoUsuario = _tipoUsuarioRepository.GetById(id).Result;
        _tipoUsuarioRepository.Delete(id);
        await _tipoUsuarioRepository.SaveChanges();
        return tipoUsuario;
    }
}