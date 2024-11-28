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

    public Task Post(Pedido pedido)
    {
        _pedidoRepository.Create(pedido);
        return _pedidoRepository.SaveChanges();
    }

    public void Put(Pedido pedido)
    {
        _pedidoRepository.Update(pedido);
        _pedidoRepository.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _pedidoRepository.Delete(id);
        _pedidoRepository.SaveChanges();
    }
}