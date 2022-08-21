using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;

namespace MinimalApi.Api.Persistence;

public interface IAppDbContext
{
    DbSet<Ingredient> Ingredients { get; set; }
    DbSet<Drink> Drinks { get; set; }
    DbSet<DrinksIngredients> DrinksIngredients { get; set; }

    Task<int> SaveChangesAsync();
}