using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CorabastosAPI.Models;

public class TipoUsuario
{
    public Guid TipoUsuarioId { get; set; }
    public string TipoUsuarioDescripcion { get; set; }
    
    [JsonIgnore] [ValidateNever] public virtual ICollection<Usuario> Usuarios { get; set; }
}