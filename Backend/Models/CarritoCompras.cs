namespace CorabastosAPI.Models;

public class CarritoCompras
{
    public Guid CarritoComprasId { get; set; }
    public Guid ClienteId { get; set; }
    public int CarritoComprasTotal { get; set; }
    
    public virtual ICollection<CarritoComprasProducto> CarritoComprasProductos { get; set; }
    public virtual Usuario Cliente { get; set; }
}   