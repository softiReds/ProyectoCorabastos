﻿using CorabastosAPI.Context;
using CorabastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorabastosAPI.Repositories;

public class ProductoRepository : IRepository<Producto>
{
    private CorabastosContext _dbContext;

    public ProductoRepository(CorabastosContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Producto>> Get() => await _dbContext.Productos.ToListAsync();

    public async Task<Producto> GetById(Guid id) => await _dbContext.Productos.FindAsync(id);

    public async Task Create(Producto entity) => await _dbContext.Productos.AddAsync(entity);

    public void Update(Producto entity)
    {
        _dbContext.Productos.Attach(entity);
        _dbContext.Productos.Entry(entity).State = EntityState.Modified;
    }

    public async void Delete(Guid id)
    {
        var producto = await GetById(id);
        _dbContext.Productos.Remove(producto);
    }

    public async Task SaveChanges() => await _dbContext.SaveChangesAsync();
}