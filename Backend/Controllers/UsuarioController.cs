using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _usuarioService.Get();
        return Ok(usuarios);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var usuario = await _usuarioService.GetById(id);
        return Ok(usuario);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Usuario usuario)
    {
        await _usuarioService.Post(usuario);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Usuario usuario)
    {
        _usuarioService.Put(usuario);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _usuarioService.Delete(id);
        return Ok();
    }
}