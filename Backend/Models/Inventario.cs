using System.Text.Json.Serialization;

namespace CorabastosAPI.Models;

public class Inventario
{
    public Guid InventarioId { get; set; }
    public Guid VendedorId { get; set; }

    public virtual Usuario Vendedor { get; set; }
    [JsonIgnore] public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
}