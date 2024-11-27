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

        public async Task Create(Usuario entity) => await _dbContext.Usuarios.AddAsync(entity);

        public void Update(Usuario entity)
        {
            _dbContext.Usuarios.Attach(entity);
            _dbContext.Usuarios.Entry(entity).State = EntityState.Modified;
        }

        public async void Delete(Guid id)
        {
            var usuario = await GetById(id);
            _dbContext.Usuarios.Remove(usuario);
        }

        public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
    }
}