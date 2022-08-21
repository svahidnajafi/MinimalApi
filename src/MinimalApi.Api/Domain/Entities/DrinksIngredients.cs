using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class DrinksIngredients : BaseEntity
{
    
    [Required]
    public string DrinkId { get; set; }
    public Drink Drink { get; set; }

    [Required]
    public string IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}