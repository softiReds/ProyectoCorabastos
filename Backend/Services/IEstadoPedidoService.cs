using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IEstadoPedidoService
{
    Task<List<EstadoPedido>> Get();
    Task<EstadoPedido> GetById(Guid id);
    void Post(EstadoPedido estadoPedido);
    void Put(EstadoPedido estadoPedido);
    void Delete(Guid id);
}