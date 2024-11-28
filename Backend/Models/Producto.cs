using System.Text.Json.Serialization;

namespace CorabastosAPI.Models;

public class Producto
{
    public Guid ProductoId { get; set; }
    public string ProductoNombre { get; set; }
    public int ProductoPrecio { get; set; }
    
    [JsonIgnore] public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
    [JsonIgnore] public virtual ICollection<CarritoComprasProducto> CarritoComprasProductos { get; set; }
}