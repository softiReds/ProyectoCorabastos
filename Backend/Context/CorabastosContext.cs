using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Context;

public class CorabastosContext : DbContext
{
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<TipoUsuario> TiposUsuario { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<EstadoPedido> EstadoPedidos { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<CarritoCompras> CarritosCompras { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<CarritoComprasProducto> CarritoComprasProductos { get; set; }
    public DbSet<InventarioProducto> InventarioProductos { get; set; }
    
    public CorabastosContext(DbContextOptions<CorabastosContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(ciudad =>
        {
            ciudad.ToTable("Ciudad");
            ciudad.HasKey(c => c.CiudadId);
            ciudad.Property(c => c.CiudadNombre).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<TipoUsuario>(tipoUsuario =>
        {
            tipoUsuario.ToTable("TipoUsuario");
            tipoUsuario.HasKey(tu => tu.TipoUsuarioId);
            tipoUsuario.Property(tu => tu.TipoUsuarioDescripcion).IsRequired().HasMaxLength(20);
        });

        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(u => u.UsuarioId);
            usuario.HasOne(u => u.Ciudad)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.CiudadId);
            usuario.HasOne(u => u.TipoUsuario)
                .WithMany(tu => tu.Usuarios)
                .HasForeignKey(u => u.TipoUsuarioId);
            usuario.Property(u => u.UsuarioDocumento).IsRequired().HasMaxLength(13);
            usuario.Property(u => u.UsuarioNombre).IsRequired().HasMaxLength(50);
            usuario.Property(u => u.UsuarioApellido).IsRequired().HasMaxLength(50);
            usuario.Property(u => u.UsuarioCorreo).IsRequired().HasMaxLength(80);
            usuario.Property(u => u.UsuarioTelefono).IsRequired().HasMaxLength(10);
            usuario.Property(u => u.UsuarioDireccion).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<EstadoPedido>(EstadoPedido =>
        {
            EstadoPedido.ToTable("EstadoPedido");
            EstadoPedido.HasKey(ep => ep.EstadoPedidoId);
            EstadoPedido.Property(ep => ep.EstadoPedidoDescripcion).IsRequired().HasMaxLength(30);
        });

        modelBuilder.Entity<Pedido>(pedido =>
        {
            pedido.ToTable("Pedido");
            pedido.HasKey(p => p.PedidoId);
            pedido.HasOne(p => p.Cliente)
                .WithMany(u => u.PedidosCliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            pedido.HasOne(p => p.Vendedor)
                .WithMany(u => u.PedidosVendedor)
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);
            pedido.HasOne(p => p.EstadoPedido)
                .WithMany(ep => ep.Pedidos)
                .HasForeignKey(p => p.EstadoPedidoId);
            pedido.Property(p => p.PedidoFechaCreacion).IsRequired();
            pedido.Property(p => p.PedidoFechaEntrega).IsRequired();
        });

        modelBuilder.Entity<Inventario>(inventario =>
        {
            inventario.ToTable("Inventario");
            inventario.HasKey(i => i.InventarioId);
            inventario.HasOne(i => i.Vendedor)
                .WithOne(u => u.Inventario)
                .HasForeignKey<Inventario>(i => i.VendedorId);
        });

        modelBuilder.Entity<CarritoCompras>(carritoCompras =>
        {
            carritoCompras.ToTable("CarritoCompras");
            carritoCompras.HasKey(cc => cc.CarritoComprasId);
            carritoCompras.HasOne(cc => cc.Cliente)
                .WithOne(u => u.CarritoComprasCliente)
                .HasForeignKey<CarritoCompras>(cc => cc.ClienteId);
            carritoCompras.Property(cc => cc.CarritoComprasTotal).IsRequired();
        });

        modelBuilder.Entity<Producto>(producto =>
        {
            producto.ToTable("Producto");
            producto.HasKey(pr => pr.ProductoId);
            producto.Property(pr => pr.ProductoNombre).IsRequired().HasMaxLength(100);
            producto.Property(pr => pr.ProductoPrecio).IsRequired();
        });

        modelBuilder.Entity<CarritoComprasProducto>(carritoComprasProductos =>
        {
            carritoComprasProductos.ToTable("CarritoCompras_Producto");
            carritoComprasProductos.HasKey(ccp => new { ccp.CarritoComprasId, ccp.ProductoId });
            carritoComprasProductos.HasOne(ccp => ccp.Producto)
                .WithMany(pr => pr.CarritoComprasProductos)
                .HasForeignKey(ccp => ccp.ProductoId);
            carritoComprasProductos.HasOne(ccp => ccp.CarritoCompras)
                .WithMany(cc => cc.CarritoComprasProductos)
                .HasForeignKey(ccp => ccp.CarritoComprasId);
            carritoComprasProductos.Property(ccp => ccp.Cantidad).IsRequired();
        });

        modelBuilder.Entity<InventarioProducto>(inventarioProducto =>
        {
            inventarioProducto.ToTable("Inventario_Producto");
            inventarioProducto.HasKey(ip => new { ip.InventarioId, ip.ProductoId });
            inventarioProducto.HasOne(ip => ip.Producto)
                .WithMany(pr => pr.InventarioProductos)
                .HasForeignKey(ip => ip.ProductoId);
            inventarioProducto.HasOne(ip => ip.Inventario)
                .WithMany(i => i.InventarioProductos)
                .HasForeignKey(ip => ip.InventarioId);
            inventarioProducto.Property(ip => ip.Cantidad).IsRequired();
        });
    }
}