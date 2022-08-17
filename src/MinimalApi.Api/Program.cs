using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Models;
using MinimalApi.Api.Persistence;
using MinimalApi.Api.Repositories;
using MinimalApi.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setting and providing db context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MainDatabase");
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<IAppDbContext>(provider => provider.GetService<AppDbContext>() ?? throw new InvalidOperationException());
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IDrinkRepository, DrinkRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ingredients endpoints
string ingredientsUrl = "/ingredients"; 
app.MapGet(ingredientsUrl, async (IIngredientRepository repo) => await repo.GetAsync());
app.MapPost(ingredientsUrl,
    async (IIngredientRepository repo, IngredientDto requestBody) => await repo.UpsertAsync(requestBody));
app.MapDelete(ingredientsUrl + "/{id}", async (IIngredientRepository repo, int id) => await repo.DeleteAsync(id));
app.MapPut(ingredientsUrl, 
    async (IIngredientRepository repo, IngredientDto requestBody) => await repo.UpsertAsync(requestBody));

// Drink endpoints
string drinkUrl = "/drinks"; 
app.MapGet(drinkUrl, async (IDrinkRepository repo) => await repo.GetAsync());
app.MapPost(drinkUrl,
    async (IDrinkRepository repo, DrinkDto requestBody) => await repo.UpsertAsync(requestBody));
app.MapDelete(drinkUrl + "/{id}", async (IDrinkRepository repo, int id) => await repo.DeleteAsync(id));
app.MapPut(drinkUrl, 
    async (IDrinkRepository repo, DrinkDto requestBody) => await repo.UpsertAsync(requestBody));

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}