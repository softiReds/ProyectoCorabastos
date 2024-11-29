using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class InventarioProducto
{
    public Guid InventarioId { get; set; }
    public Guid ProductoId  { get; set; }
    public int Cantidad { get; set; }
    
    [ValidateNever] public virtual Inventario Inventario { get; set; }
    [ValidateNever] public virtual Producto Producto { get; set; }
}