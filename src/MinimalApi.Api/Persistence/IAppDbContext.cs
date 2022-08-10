using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;

namespace MinimalApi.Api.Persistence;

public interface IAppDbContext
{
    DbSet<Ingredient> Ingredients { get; set; }
    DbSet<Drink> Drinks { get; set; }

    Task<int> SaveChangesAsync();
}