namespace CorabastosAPI.Models.Containers;

public class CarritoComprasRequest
{
    public CarritoComprasRequest(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto)
    {
        CarritoCompras = carritoCompras;
        CarritoComprasProducto = carritoComprasProducto;
    }

    public CarritoCompras CarritoCompras { get; set; }
    public CarritoComprasProducto CarritoComprasProducto { get; set; }
}