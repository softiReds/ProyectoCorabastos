namespace CorabastosAPI.Models;

public class EstadoPedido
{
    public Guid EstadoPedidoId { get; set; }
    public string EstadoPedidoDescripcion { get; set; }
    
    public virtual ICollection<Pedido> Pedidos { get; set; }
}