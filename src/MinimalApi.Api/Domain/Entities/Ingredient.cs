using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Api.Domain.Entities;

public class Ingredient
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}