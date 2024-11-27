using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly CorabastosContext _dbContext;

        public UsuarioRepository(CorabastosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> Get() => await _dbContext.Usuarios.ToListAsync();

        public async Task<Usuario> GetById(Guid id) => await _dbContext.Usuarios.FindAsync(id);

        public Task<Usuario> GetById(Guid id1, Guid id2)
            => throw new NotSupportedException("Use el método GetById(Guid id).");

        public async Task Create(Usuario entidad) => await _dbContext.Usuarios.AddAsync(entidad);

        public void Update(Usuario entidad)
        {
            _dbContext.Usuarios.Attach(entidad);
            _dbContext.Usuarios.Entry(entidad).State = EntityState.Modified;
        }

        public async void Delete(Guid id)
        {
            var usuario = await GetById(id);
            _dbContext.Usuarios.Remove(usuario);
        }

        public void Delete(Guid id1, Guid id2)
            => throw new NotSupportedException("Use el método Delete(Guid id).");

        public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
    }
}