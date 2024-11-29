using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class CarritoComprasProducto
{
    public Guid CarritoComprasId { get; set; }
    public Guid ProductoId { get; set; }
    public int Cantidad { get; set; }

    [ValidateNever] public virtual Producto Producto { get; set; }
    [ValidateNever] public virtual CarritoCompras CarritoCompras { get; set; }
}