using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Ingredient : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public int? DrinkId { get; set; }
    public Drink? Drink { get; set; }
}