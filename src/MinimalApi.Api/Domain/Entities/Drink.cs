using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Drink : BaseEntity
{
    public Drink()
    {
        DrinksIngredients = new List<DrinksIngredients>();
    }
    
    [Required]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string Recipe { get; set; }
    
    public IList<DrinksIngredients> DrinksIngredients { get; set; }
}