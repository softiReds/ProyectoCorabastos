using CorabastosAPI.Context;
using CorabastosAPI.Models;
using CorabastosAPI.Repositories;
using CorabastosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CorabastosContext>(e =>
    e.UseSqlServer(builder.Configuration.GetConnectionString("azureConnection")));

//  Services
builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<ICarritoComprasService, CarritoComprasService>();
builder.Services.AddScoped<IEstadoPedidoService, EstadoPedidoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

//  Repositories
builder.Services.AddScoped<IRepository<Ciudad>, CiudadRepository>();
builder.Services.AddScoped<IRepository<CarritoCompras>, CarritoComprasRepository>();
builder.Services.AddScoped<IRepository<EstadoPedido>, EstadoPedidoRepository>();
builder.Services.AddScoped<IRepository<Pedido>, PedidoRepository>();
builder.Services.AddScoped<IRepository<TipoUsuario>, TipoUsuarioRepository>();
builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IRepository<Inventario>, InventarioRepository>();
builder.Services.AddScoped<IRepository<Producto>, ProductoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/bdConexion", async ([FromServices] CorabastosContext context) =>
{
    context.Database.EnsureCreated();

    return Results.Ok("Conexión exitosa");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();