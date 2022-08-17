using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Drink : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Recipe { get; set; }
    public IList<Ingredient> Ingredients { get; set; }
}