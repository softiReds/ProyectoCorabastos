using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class EstadoPedidoService : IEstadoPedidoService
{
    private readonly IRepository<EstadoPedido> _estadoPedidoRepository;

    public EstadoPedidoService(IRepository<EstadoPedido> estadoPedidoRepository)
    {
        _estadoPedidoRepository = estadoPedidoRepository;
    }

    public Task<List<EstadoPedido>> Get() => _estadoPedidoRepository.Get();

    public Task<EstadoPedido> GetById(Guid id) => _estadoPedidoRepository.GetById(id);

    public async Task<EstadoPedido> Post(EstadoPedido estadoPedido)
    {
        await _estadoPedidoRepository.Create(estadoPedido);
        await _estadoPedidoRepository.SaveChanges();
        return estadoPedido;
    }

    public async Task<EstadoPedido> Put(EstadoPedido estadoPedido)
    {
        _estadoPedidoRepository.Update(estadoPedido);
        await _estadoPedidoRepository.SaveChanges();
        return estadoPedido;
    }

    public async Task<EstadoPedido> Delete(Guid id)
    {
        var estadoPedido = await _estadoPedidoRepository.GetById(id);
        _estadoPedidoRepository.Delete(id);
        await _estadoPedidoRepository.SaveChanges();
        return estadoPedido;
    }
}