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
        var carritoComprasProductoDb =
            await _carritoComprasProductoRepository.GetById(carritoCompras.CarritoComprasId, carritoComprasProducto.ProductoId);

        if (agregarProducto)
        {
            await AgregarProducto(carritoCompras, carritoComprasProducto, carritoComprasProductoDb);
        }
        else
        {
            await QuitarProducto(carritoCompras, carritoComprasProducto, carritoComprasProductoDb);
        }

        _carritoComprasRepository.Update(carritoCompras);
        await _carritoComprasRepository.SaveChanges();
        await _carritoComprasProductoRepository.SaveChanges();
        return carritoCompras;
    }

    private async Task AgregarProducto(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto,
        CarritoComprasProducto carritoComprasProductoDb)
    {
        (carritoCompras.CarritoComprasTotal, carritoComprasProducto.Cantidad) = AgregarProductoTotalCarrito(carritoCompras.CarritoComprasTotal,
            carritoComprasProducto.ProductoId, carritoComprasProducto.Cantidad, carritoComprasProductoDb?.Cantidad ?? 0);
        if (carritoComprasProductoDb != null)
            _carritoComprasProductoRepository.Update(carritoComprasProducto);
        else
            await _carritoComprasProductoRepository.Create(carritoComprasProducto);
    }

    private async Task QuitarProducto(CarritoCompras carritoCompras, CarritoComprasProducto carritoComprasProducto,
        CarritoComprasProducto carritoComprasProductoDb)
    {
        (carritoCompras.CarritoComprasTotal, carritoComprasProducto.Cantidad) = QuitarProductoTotalCarrito(carritoCompras.CarritoComprasTotal,
            carritoComprasProducto.ProductoId, carritoComprasProducto.Cantidad, carritoComprasProductoDb.Cantidad);

        if (carritoComprasProducto.Cantidad == 0)
            await _carritoComprasProductoRepository.Delete(carritoCompras.CarritoComprasId, carritoComprasProducto.ProductoId);
        else
            _carritoComprasProductoRepository.Update(carritoComprasProducto);
    }

    public async Task<CarritoCompras> Delete(Guid id)
    {
        var carritoCompras = await _carritoComprasRepository.GetById(id);
        _carritoComprasRepository.Delete(id);
        await _carritoComprasRepository.SaveChanges();
        return carritoCompras;
    }

    public (int totalCarrito, int cantidadProducto) AgregarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProductoAgregado,
        int cantidadProducto)
    {
        var producto = _productoRepository.GetById(idProducto).Result;
        var precioProductos = 0;
        for (var i = 0; i < cantidadProductoAgregado; i++)
        {
            precioProductos += producto.ProductoPrecio;
        }

        totalCarrito += precioProductos;
        cantidadProducto += cantidadProductoAgregado;
        return (totalCarrito, cantidadProducto);
    }

    public (int totalCarrito, int cantidadProducto) QuitarProductoTotalCarrito(int totalCarrito, Guid idProducto, int cantidadProductoEliminado,
        int cantidadProducto)
    {
        var producto = _productoRepository.GetById(idProducto).Result;
        var precioProductos = 0;
        for (var i = 0; i < cantidadProductoEliminado; i++)
        {
            precioProductos += producto.ProductoPrecio;
        }

        totalCarrito -= precioProductos;
        cantidadProducto -= cantidadProductoEliminado;
        return (totalCarrito, cantidadProducto);
    }
}