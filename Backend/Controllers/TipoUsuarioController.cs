using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private readonly ITipoUsuarioService _tipoUsuarioService;

    public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService) => _tipoUsuarioService = tipoUsuarioService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tipoUsuario = await _tipoUsuarioService.Get();
        return Ok(tipoUsuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var tipoUsuario = await _tipoUsuarioService.GetById(id);
        return Ok(tipoUsuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TipoUsuario tipoUsuario)
    {
        await _tipoUsuarioService.Post(tipoUsuario);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] TipoUsuario tipoUsuario)
    {
        _tipoUsuarioService.Put(tipoUsuario);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _tipoUsuarioService.Delete(id);
        return Ok();
    }
}