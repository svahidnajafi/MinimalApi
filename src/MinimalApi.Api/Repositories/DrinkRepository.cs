using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;
using MinimalApi.Api.Persistence;
using MinimalApi.Api.Repositories.Interfaces;

namespace MinimalApi.Api.Repositories;

public class DrinkRepository : GenericRepository<Drink, DrinkDto>, IDrinkRepository
{
    public DrinkRepository(IAppDbContext context, IMapper mapper) 
        : base(context.Drinks, context, mapper) { }

    public override async Task<IEnumerable<DrinkDto>> GetAsync(Predicate<Drink>? predicate = null)
    {
        IQueryable<Drink> queryable = Context.Drinks.AsNoTracking()
            .Include(e => e.DrinksIngredients)
            .ThenInclude(d => d.Ingredient);
        if (predicate != null)
            queryable = queryable.Where(e => predicate(e));
        IEnumerable<DrinkDto> result = await queryable
            .Select(e => new DrinkDto()
            {
                Id = e.Id,
                Name = e.Name,
                Recipe = e.Recipe,
                Ingredients = e.DrinksIngredients.Select(d => new IngredientDto()
                {
                    Id = d.Ingredient.Id,
                    Name = d.Ingredient.Name
                })
            })
            .ToListAsync();
        return result;
    }
}