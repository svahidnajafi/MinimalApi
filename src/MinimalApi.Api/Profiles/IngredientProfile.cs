using AutoMapper;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Profiles;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<Ingredient, IngredientDto>().ReverseMap();
    }
}