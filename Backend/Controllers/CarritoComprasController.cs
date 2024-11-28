using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarritoComprasController : ControllerBase
{
    private readonly ICarritoComprasService _carritoComprasService;

    public CarritoComprasController(ICarritoComprasService carritoComprasService) => _carritoComprasService = carritoComprasService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var carritoCompras = await _carritoComprasService.Get();
        return Ok(carritoCompras);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var carritoCompras = await _carritoComprasService.GetById(id);
        return Ok(carritoCompras);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CarritoCompras carritoCompras)
    {
        await _carritoComprasService.Post(carritoCompras);
        return Ok();
    }
    
    [HttpPut("{agregarProducto}")]
    public async Task<IActionResult> Put([FromBody] CarritoCompras carritoCompras, [FromBody] CarritoComprasProducto carritoComprasProducto, [FromRoute] bool agregarProducto)
    {
        await _carritoComprasService.Put(carritoCompras, carritoComprasProducto, agregarProducto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _carritoComprasService.Delete(id);
        return Ok();
    }
}