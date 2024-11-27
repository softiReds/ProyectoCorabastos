using CorabastosAPI.Models;

namespace CorabastosAPI.Services;

public interface IPedidoService
{
    Task<List<Pedido>> Get();
    Task<Pedido> GetById(Guid id);
    Task Post(Pedido pedido);
    void Put(Pedido pedido);
    void Delete(Guid id);
}