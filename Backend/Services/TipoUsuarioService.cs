using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly IRepository<TipoUsuario> _tipoUsuarioRepository;

        public TipoUsuarioService(IRepository<TipoUsuario> tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public Task<List<TipoUsuario>> Get() => _tipoUsuarioRepository.Get();

        public Task<TipoUsuario> GetById(Guid id) => _tipoUsuarioRepository.GetById(id);

        public Task Post(TipoUsuario tipoUsuario)
        { 
            _tipoUsuarioRepository.Create(tipoUsuario);
            return _tipoUsuarioRepository.SaveChanges();
        }

        public void Put(TipoUsuario tipoUsuario)
        {
            _tipoUsuarioRepository.Update(tipoUsuario);
            _tipoUsuarioRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _tipoUsuarioRepository.Delete(id);
            _tipoUsuarioRepository.SaveChanges();
        }
    }
}