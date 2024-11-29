using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class EstadoPedido
{
    public Guid EstadoPedidoId { get; set; }
    public string EstadoPedidoDescripcion { get; set; }

    [JsonIgnore] [ValidateNever] public virtual ICollection<Pedido> Pedidos { get; set; }
}