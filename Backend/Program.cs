using CorabastosAPI.Context;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSqlServer<CorabastosContext>(builder.Configuration.GetConnectionString("santiagoWorkConnection"));
//builder.Services.AddSqlServer<CorabastosContext>(builder.Configuration.GetConnectionString("ximenaConnection"));
builder.Services.AddSqlServer<CorabastosContext>(builder.Configuration.GetConnectionString("andresConnection"));

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

app.Run();