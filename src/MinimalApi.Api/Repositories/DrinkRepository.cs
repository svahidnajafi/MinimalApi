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
                Ingredients = e.DrinksIngredients.Select(e => Map(e))
            })
            .ToListAsync();
        return result;
    }


    public override async Task<DrinkDto?> GetByIdAsync(string id)
    {
        Drink? drink = await Context.Drinks.AsNoTracking()
            .Include(e => e.DrinksIngredients)
            .ThenInclude(e => e.Ingredient)
            .SingleOrDefaultAsync(e => e.Id == id);
        if (drink == null) 
            return default;
        DrinkDto result = Mapper.Map<DrinkDto>(drink);
        result.Ingredients = drink.DrinksIngredients.Select(e => Map(e)).ToList();
        return result;
    }

    private static IngredientDto Map(DrinksIngredients drinksIngredients) => new()
        {
            Id = drinksIngredients.Ingredient.Id,
            Name = drinksIngredients.Ingredient.Name
        };
}