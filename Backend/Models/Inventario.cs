using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class Inventario
{
    public Guid InventarioId { get; set; }
    public Guid VendedorId { get; set; }

    public virtual Usuario Vendedor { get; set; }
    [JsonIgnore] [ValidateNever] public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
}