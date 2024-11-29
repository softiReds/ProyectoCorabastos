using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class PedidoService : IPedidoService
{
    private readonly IRepository<Pedido> _pedidoRepository;

    public PedidoService(IRepository<Pedido> pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public Task<List<Pedido>> Get() => _pedidoRepository.Get();

    public Task<Pedido> GetById(Guid id) => _pedidoRepository.GetById(id);

    public async Task<Pedido> Post(Pedido pedido)
    {
        await _pedidoRepository.Create(pedido);
        await _pedidoRepository.SaveChanges();
        return pedido;
    }

    public async Task<Pedido> Put(Pedido pedido)
    {
        _pedidoRepository.Update(pedido);
        await _pedidoRepository.SaveChanges();
        return pedido;
    }

    public async Task<Pedido> Delete(Guid id)
    {
        var pedido = await _pedidoRepository.GetById(id);
        _pedidoRepository.Delete(id);
        await _pedidoRepository.SaveChanges();
        return pedido;
    }
}