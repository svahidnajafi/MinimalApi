using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Api.Domain.Entities;
using MinimalApi.Api.Persistence;
using MinimalApi.IntegrationTest.Common.Storages;
using Respawn;
using Respawn.Graph;

namespace MinimalApi.IntegrationTest;

[SetUpFixture]
public class Testing
{
    private static MinimalApiApplication _application = null!;
    private static IServiceScopeFactory _scopeFactory = null!;
    private static IConfiguration _configuration = null!;
    private static Checkpoint _checkpoint = null!;
    
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        _application = new MinimalApiApplication();
        _scopeFactory = _application.Services.GetRequiredService<IServiceScopeFactory>();
        _configuration = _application.Services.GetRequiredService<IConfiguration>();
        _checkpoint = new Checkpoint
        {
            TablesToIgnore = new Table[] { "__EFMigrationsHistory" }
        };
    }
    
    public static HttpClient GetClient() => _application.CreateClient();
    
    public static IServiceScopeFactory ScopeFactory => _scopeFactory;
    
    public static async Task ResetStateAsync()
    {
        await _checkpoint.Reset(_configuration.GetConnectionString("TestAppConnectionString"));
    }
    
    public static async Task SeedDefaultDataAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
        await initializer.SeedAsync();
    }
}