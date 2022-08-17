using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Repositories.Interfaces;

public interface IIngredientRepository : IGenericRepository<Ingredient, IngredientDto>
{
}