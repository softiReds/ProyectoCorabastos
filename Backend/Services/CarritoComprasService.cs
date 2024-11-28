using CorabastosAPI.Models;
using CorabastosAPI.Repositories;

namespace CorabastosAPI.Services;

public class CarritoComprasService : ICarritoComprasService
{
    private readonly IRepository<CarritoCompras> _carritoComprasRepository;
    private readonly IRepository<Producto> _productoRepository;
    private readonly IRepository<CarritoComprasProducto> _carritoComprasProductoRepository;

    public CarritoComprasService(IRepository<CarritoCompras> carritoComprasRepository,
        IRepository<Producto> productoRepository, IRepository<CarritoComprasProducto> carritoComprasProductoRepository)
    {
        _carritoComprasRepository = carritoComprasRepository;
        _productoRepository = productoRepository;
        _carritoComprasProductoRepository = carritoComprasProductoRepository;
    }

    public Task<List<CarritoCompras>> Get() => _carritoComprasRepository.Get();

    public Task<CarritoCompras> GetById(Guid id) => _carritoComprasRepository.GetById(id);

    public async Task<CarritoCompras> Post(CarritoCompras carritoCompras)
    {
        await _carritoComprasRepository.Create(carritoCompras);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public async Task<CarritoCompras> Put(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto, bool agregarProducto)
    {
        if (agregarProducto)
        {
            carritoCompras.CarritoComprasTotal = AgregarProductoTotalCarrito(carritoCompras.CarritoComprasTotal,
                carritoComprasProducto.ProductoId, carritoComprasProducto.Cantidad);
            await _carritoComprasProductoRepository.Create(carritoComprasProducto);
        }
        else
        {
            carritoCompras.CarritoComprasTotal = QuitarProductoTotalCarrito(carritoCompras.CarritoComprasTotal,
                carritoComprasProducto.ProductoId, carritoComprasProducto.Cantidad);
            _carritoComprasProductoRepository.Delete(carritoComprasProducto.CarritoComprasId, carritoComprasProducto.ProductoId);
        }
        
        _carritoComprasRepository.Update(carritoCompras);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public async Task<CarritoCompras> Delete(Guid id)
    {
        var carritoCompras = await _carritoComprasRepository.GetById(id);
        _carritoComprasRepository.Delete(id);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public int AgregarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProducto)
    {
        var producto = _productoRepository.GetById(idProducto).Result;
        var precioProductos = 0;
        for (var i = 0; i < cantidadProducto; i++)
        {
            precioProductos += producto.ProductoPrecio;
        }

        totalCarrito += precioProductos;
        return totalCarrito;
    }

    public int QuitarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProducto)
    {
        var producto = _productoRepository.GetById(idProducto).Result;
        var precioProductos = 0;
        for (var i = 0; i < cantidadProducto; i++)
        {
            precioProductos += producto.ProductoPrecio;
        }

        totalCarrito -= precioProductos;
        return totalCarrito;
    }
}