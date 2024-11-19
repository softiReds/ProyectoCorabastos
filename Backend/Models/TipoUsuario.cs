namespace CorabastosAPI.Models;

public class TipoUsuario
{
    public Guid TipoUsuarioId { get; set; }
    public string TipoUsuarioDescripcion { get; set; }
    
    public virtual ICollection<Usuario> Usuarios { get; set; }
}