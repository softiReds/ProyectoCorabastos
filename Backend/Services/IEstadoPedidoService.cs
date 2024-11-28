using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IEstadoPedidoService
{
    Task<List<EstadoPedido>> Get();
    Task<EstadoPedido> GetById(Guid id);
    Task<EstadoPedido> Post(EstadoPedido estadoPedido);
    Task<EstadoPedido> Put(EstadoPedido estadoPedido);
    Task<EstadoPedido> Delete(Guid id);
}