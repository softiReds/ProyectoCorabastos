using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService) => _productoService = productoService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productos = await _productoService.Get();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var producto = await _productoService.GetById(id);
        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Producto producto)
    {
        await _productoService.Post(producto);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Producto producto)
    {
        _productoService.Put(producto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _productoService.Delete(id);
        return Ok();
    }
}