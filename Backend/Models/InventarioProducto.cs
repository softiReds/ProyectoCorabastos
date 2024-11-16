namespace CorabastosAPI.Models;

public class InventarioProducto
{
    public Guid InventarioId { get; set; }
    public Guid ProductoId  { get; set; }
    public int Cantidad { get; set; }
    
    public virtual Inventario Inventario { get; set; }
    public virtual Producto Producto { get; set; }
}