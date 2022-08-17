using AutoMapper;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Profiles;

public class DrinkProfile : Profile
{
    public DrinkProfile()
    {
        CreateMap<Drink, DrinkDto>().ReverseMap();
    }
}