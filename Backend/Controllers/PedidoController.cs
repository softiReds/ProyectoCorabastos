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
    public IActionResult Post([FromBody] Pedido pedido)
    {
        _pedidoService.Post(pedido);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Pedido pedido)
    {
        _pedidoService.Put(pedido);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _pedidoService.Delete(id);
        return Ok();
    }
}