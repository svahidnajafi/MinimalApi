using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;

namespace MinimalApi.Api.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Drink> Drinks { get; set; }

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
}