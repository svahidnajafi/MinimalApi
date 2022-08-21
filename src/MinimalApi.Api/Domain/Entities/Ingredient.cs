using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Ingredient : BaseEntity
{
    public Ingredient()
    {
        DrinksIngredients = new List<DrinksIngredients>();
    }
    
    [Required]
    public string Name { get; set; }

    public IList<DrinksIngredients> DrinksIngredients { get; set; }
}