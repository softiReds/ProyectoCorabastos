using CorabastosAPI.Models;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorabastosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CiudadController : ControllerBase
{
    private readonly ICiudadService _ciudadService;
    
    public CiudadController(ICiudadService ciudadService) => _ciudadService = ciudadService;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ciudades = await _ciudadService.Get();
        return Ok(ciudades);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var ciudad = await _ciudadService.GetById(id);
        return Ok(ciudad);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Ciudad ciudad)
    {
        await _ciudadService.Post(ciudad);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Ciudad ciudad)
    {
        _ciudadService.Put(ciudad);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _ciudadService.Delete(id);
        return Ok();
    }
}