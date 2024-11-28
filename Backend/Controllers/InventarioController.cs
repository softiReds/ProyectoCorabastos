using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventarioController : ControllerBase
{
    private readonly IInventarioService _inventarioService;

    public InventarioController(IInventarioService inventarioService) => _inventarioService = inventarioService;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var inventarios = await _inventarioService.Get();
        return Ok(inventarios);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var inventario = await _inventarioService.GetById(id);
        return Ok(inventario);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Inventario inventario)
    {
        _inventarioService.Post(inventario);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Inventario inventario)
    {
        await _inventarioService.Put(inventario);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _inventarioService.Delete(id);
        return Ok();
    }
}