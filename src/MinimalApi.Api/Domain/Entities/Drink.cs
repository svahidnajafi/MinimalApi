using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Drink
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Recipe { get; set; }
    public IList<Ingredient> Ingredients { get; set; }
}