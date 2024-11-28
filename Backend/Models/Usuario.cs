using System.Text.Json.Serialization;

namespace CorabastosAPI.Models;

public class Usuario
{
    public Guid UsuarioId { get; set; }
    public Guid CiudadId { get; set; }
    public Guid TipoUsuarioId { get; set; }
    public string UsuarioDocumento { get; set; }
    public string UsuarioNombre { get; set; }
    public string UsuarioApellido { get; set; }
    public string UsuarioCorreo { get; set; }
    public string UsuarioTelefono { get; set; }
    public string UsuarioDireccion { get; set; }

    public virtual Ciudad Ciudad { get; set; }
    public virtual TipoUsuario TipoUsuario { get; set; }
    [JsonIgnore] public virtual Inventario? Inventario { get; set; }
    [JsonIgnore] public virtual ICollection<Pedido>? PedidosCliente { get; set; }
    [JsonIgnore] public virtual ICollection<Pedido>? PedidosVendedor { get; set; }
    [JsonIgnore] public virtual CarritoCompras? CarritoComprasCliente { get; set; }
}