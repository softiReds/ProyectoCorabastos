namespace CorabastosAPI.Models;

public class Producto
{
    public Guid ProductoId { get; set; }
    public string ProductoNombre { get; set; }
    public int ProductoCantidad { get; set; }
    public int ProductoPrecio { get; set; }
}