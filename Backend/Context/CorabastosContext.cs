using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Context;

public class CorabastosContext : DbContext
{
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<TipoUsuario> TiposUsuario { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
    public CorabastosContext(DbContextOptions<CorabastosContext> options) : base(options) { }
    
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
    }
}