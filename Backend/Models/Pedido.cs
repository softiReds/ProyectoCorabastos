namespace CorabastosAPI.Models;

public class Pedido
{
    public Guid PedidoId { get; set; }
    public Guid ClienteId { get; set; }
    public Guid VendedorId { get; set; }
    public Guid EstadoPedidoId { get; set; }
    public DateTime PedidoFechaCreacion { get; set; }
    public DateTime PedidoFechaEntrega { get; set; }
    
    public virtual EstadoPedido EstadoPedido { get; set; } 
    public virtual Usuario Cliente { get; set; } 
    public virtual Usuario Vendedor { get; set; } 
}