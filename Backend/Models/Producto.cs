using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class Producto
{
    public Guid ProductoId { get; set; }
    public string ProductoNombre { get; set; }
    public int ProductoPrecio { get; set; }
    
    [JsonIgnore] [ValidateNever] public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
    [JsonIgnore] [ValidateNever] public virtual ICollection<CarritoComprasProducto> CarritoComprasProductos { get; set; }
}