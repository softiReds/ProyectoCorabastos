using System.Text.Json.Serialization;

namespace CorabastosAPI.Models;

public class EstadoPedido
{
    public Guid EstadoPedidoId { get; set; }
    public string EstadoPedidoDescripcion { get; set; }

    [JsonIgnore] public virtual ICollection<Pedido>? Pedidos { get; set; }
}