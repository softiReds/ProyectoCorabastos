using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class PedidoRepository : IRepository<Pedido>
{
    private readonly CorabastosContext _dbContext;

    public PedidoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Pedido>> Get() => await _dbContext.Pedidos.ToListAsync();

    public async Task<Pedido> GetById(Guid id) => await _dbContext.Pedidos.FindAsync(id);
    
    public Task<Pedido> GetById(Guid id1, Guid id2) => throw new NotSupportedException("Use el método GetById(Guid id).");

    public async Task Create(Pedido entidad) => await _dbContext.Pedidos.AddAsync(entidad);

    public void Update(Pedido entidad)
    {
        _dbContext.Pedidos.Attach(entidad);
        _dbContext.Pedidos.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var pedido = await GetById(id);
        _dbContext.Pedidos.Remove(pedido);
    }

    public void Delete(Guid id1, Guid id2) => throw new NotSupportedException("Use el método Delete(Guid id).");

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}