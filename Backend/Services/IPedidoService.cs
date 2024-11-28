using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IPedidoService
{
    Task<List<Pedido>> Get();
    Task<Pedido> GetById(Guid id);
    Task<Pedido> Post(Pedido pedido);
    Task<Pedido> Put(Pedido pedido);
    Task<Pedido> Delete(Guid id);
}