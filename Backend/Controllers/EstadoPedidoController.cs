using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoPedidoController : ControllerBase
{
    private readonly IEstadoPedidoService _estadoPedidoService;

    public EstadoPedidoController(IEstadoPedidoService estadoPedidoService) => _estadoPedidoService = estadoPedidoService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var estadoPedido = await _estadoPedidoService.Get();
        return Ok(estadoPedido);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var estadoPedido = await _estadoPedidoService.GetById(id);
        return Ok(estadoPedido);
    }

    [HttpPost]
    public IActionResult Post([FromBody] EstadoPedido estadoPedido)
    {
        _estadoPedidoService.Post(estadoPedido);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] EstadoPedido estadoPedido)
    {
        _estadoPedidoService.Put(estadoPedido);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _estadoPedidoService.Delete(id);
        return Ok();
    }
}