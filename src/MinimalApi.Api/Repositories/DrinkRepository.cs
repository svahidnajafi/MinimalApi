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
}