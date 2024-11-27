using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<List<Usuario>> Get() => _usuarioRepository.Get();

        public Task<Usuario> GetById(Guid id) => _usuarioRepository.GetById(id);

        public Task Post(Usuario usuario) => _usuarioRepository.Create(usuario);

        public void Put(Usuario usuario) => _usuarioRepository.Update(usuario);

        public void Delete(Guid id) => _usuarioRepository.Delete(id);
    }
}