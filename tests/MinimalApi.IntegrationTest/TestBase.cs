using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Persistence;
using MinimalApi.IntegrationTest.Common.Storages;

namespace MinimalApi.IntegrationTest;

using static Testing;

[TestFixture]
public abstract class TestBase
{
    protected HttpClient HttpClient = null!;
    protected IServiceScope Scope = null!;
    
    [SetUp]
    public async Task BaseSetUp()
    {
        await ResetStateAsync();
        await SeedDefaultDataAsync();
        HttpClient = GetHttpClient();
        Scope = GetScopeFactory().CreateScope();
        
    }
    
    protected IServiceScopeFactory GetScopeFactory() => ScopeFactory;
    
    protected HttpClient GetHttpClient() => GetClient();

    protected async Task SeedTestDataAsync()
    {
        using var scope = ScopeFactory.CreateScope();
        AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        foreach (Drink drink in ExampleData.ExampleDrinks)
            context.Add(drink);
        foreach (Ingredient ingredient in ExampleData.ExampleIngredients)
            context.Add(ingredient);
        foreach (DrinksIngredients drinksIngredients in ExampleData.ExampleDrinksIngredients)
            context.Add(drinksIngredients);
        await context.SaveChangesAsync();
    }
}