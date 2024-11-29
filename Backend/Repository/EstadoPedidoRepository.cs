using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class EstadoPedidoRepository : IRepository<EstadoPedido>
{
    private readonly CorabastosContext _dbContext;

    public EstadoPedidoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EstadoPedido>> Get() => await _dbContext.EstadoPedidos.ToListAsync();

    public async Task<EstadoPedido> GetById(Guid id) => await _dbContext.EstadoPedidos.FindAsync(id);

    public Task<EstadoPedido> GetById(Guid id1, Guid id2) => throw new NotSupportedException("Use el método GetById(Guid id).");

    public async Task Create(EstadoPedido entidad) => await _dbContext.EstadoPedidos.AddAsync(entidad);

    public void Update(EstadoPedido entidad)
    {
        _dbContext.EstadoPedidos.Attach(entidad);
        _dbContext.EstadoPedidos.Entry(entidad).State = EntityState.Modified;
    }

    public async Task Delete(Guid id)
    {
        var estadopedido = await GetById(id);
        _dbContext.EstadoPedidos.Remove(estadopedido);
    }

    public Task Delete(Guid id1, Guid id2) => throw new NotSupportedException("Use el método Delete(Guid id).");

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}