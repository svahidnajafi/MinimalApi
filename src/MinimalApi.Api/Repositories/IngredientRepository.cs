using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;
using MinimalApi.Api.Persistence;
using MinimalApi.Api.Repositories.Interfaces;

namespace MinimalApi.Api.Repositories;

public class IngredientRepository : GenericRepository<Ingredient, IngredientDto>, IIngredientRepository
{
    public IngredientRepository(IAppDbContext context, IMapper mapper)
        : base(context.Ingredients, context, mapper) { }
}