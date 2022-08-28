using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Api.Persistence;

namespace MinimalApi.IntegrationTest.Basic;

public class DatabaseTests : TestBase
{
    [Test]
    public async Task ShouldSuccessfullySeedDataToDatabaseAsync()
    {
        // Arrange
        AppDbContext context = Scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Act
        await SeedTestDataAsync();
        
        // Assert
        context.Drinks.ToList().Should().NotBeNullOrEmpty();
        context.Ingredients.ToList().Should().NotBeNullOrEmpty();
        context.DrinksIngredients.ToList().Should().NotBeNullOrEmpty();
    }
}