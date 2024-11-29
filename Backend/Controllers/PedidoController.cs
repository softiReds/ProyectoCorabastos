using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService) => _pedidoService = pedidoService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pedido = await _pedidoService.Get();
        return Ok(pedido);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var pedido = await _pedidoService.GetById(id);
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido)
    {
        await _pedidoService.Post(pedido);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Pedido pedido)
    {
        await _pedidoService.Put(pedido);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _pedidoService.Delete(id);
        return Ok();
    }
}