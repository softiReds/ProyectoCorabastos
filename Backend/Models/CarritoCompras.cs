using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class CarritoCompras
{
    public Guid CarritoComprasId { get; set; }
    public Guid ClienteId { get; set; }
    public int CarritoComprasTotal { get; set; }

    [ValidateNever] public virtual Usuario Cliente { get; set; }

    [JsonIgnore]
    [ValidateNever]
    public virtual ICollection<CarritoComprasProducto> CarritoComprasProductos { get; set; }
}