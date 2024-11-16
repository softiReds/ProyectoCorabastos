namespace CorabastosAPI.Models;

public class Inventario
{
    public Guid InventarioId { get; set; }
    public Guid VendedorId { get; set; }

    public virtual Usuario Usuario { get; set; }
    public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
}