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

    public Task Post(EstadoPedido estadoPedido) => _estadoPedidoRepository.Create(estadoPedido);

    public void Put(EstadoPedido estadoPedido) => _estadoPedidoRepository.Update(estadoPedido);

    public void Delete(Guid id) => _estadoPedidoRepository.Delete(id);
}