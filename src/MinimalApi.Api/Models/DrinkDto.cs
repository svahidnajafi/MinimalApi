namespace MinimalApi.Api.Models;

public class DrinkDto : BaseDto
{
    public string Name { get; set; }
    public string Recipe { get; set; }

    public IEnumerable<IngredientDto> Ingredients { get; set; }
}