using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories
{
    public class TipoUsuarioRepository : IRepository<TipoUsuario>
    {
        private readonly CorabastosContext _dbContext;

        public TipoUsuarioRepository(CorabastosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoUsuario>> Get() => await _dbContext.TiposUsuario.ToListAsync();

        public async Task<TipoUsuario> GetById(Guid id) => await _dbContext.TiposUsuario.FindAsync(id);

        public Task<TipoUsuario> GetById(Guid id1, Guid id2) => throw new NotSupportedException("Use el método GetById(Guid id).");

        public async Task Create(TipoUsuario entidad) => await _dbContext.TiposUsuario.AddAsync(entidad);

        public void Update(TipoUsuario entidad)
        {
            _dbContext.TiposUsuario.Attach(entidad);
            _dbContext.TiposUsuario.Entry(entidad).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            var tipoUsuario = await GetById(id);
            _dbContext.TiposUsuario.Remove(tipoUsuario);
        }

        public Task Delete(Guid id1, Guid id2) => throw new NotSupportedException("Use el método Delete(Guid id).");

        public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
    }
}