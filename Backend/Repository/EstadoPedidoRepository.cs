using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class EstadoPedidoRepository
{
    private readonly CorabastosContext _dbContext;

    public EstadoPedidoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EstadoPedido>> Get() => await _dbContext.EstadoPedidos.ToListAsync();

    public async Task<EstadoPedido> GetById(Guid id) => await _dbContext.EstadoPedidos.FindAsync(id);
    
    public async Task Create(EstadoPedido entidad) => await _dbContext.EstadoPedidos.AddAsync(entidad);

    public void Update(EstadoPedido entidad)
    {
        _dbContext.EstadoPedidos.Attach(entidad);
        _dbContext.EstadoPedidos.Entry(entidad).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var estadopedido = await GetById(id);
        _dbContext.EstadoPedidos.Remove(estadopedido);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}