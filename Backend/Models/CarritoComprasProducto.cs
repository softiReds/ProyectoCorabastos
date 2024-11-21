namespace CorabastosAPI.Models;

public class CarritoComprasProducto
{
    public Guid CarritoComprasId { get; set; }
    public Guid ProductoId { get; set; }
    public int Cantidad { get; set; }
    
    public virtual Producto Producto { get; set; }
    public virtual CarritoCompras CarritoCompras { get; set; }
}