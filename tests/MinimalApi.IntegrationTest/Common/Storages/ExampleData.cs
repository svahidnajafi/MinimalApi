using MinimalApi.Api.Domain.Entities;

namespace MinimalApi.IntegrationTest.Common.Storages;

public static class ExampleData
{
    public static List<Ingredient> ExampleIngredients => new()
    {
        new() { Id = "ing_1", Name = "Water"},
        new() { Id = "ing_2", Name = "Ice"},
        new() { Id = "ing_3", Name = "Milk"},
        new() { Id = "ing_4", Name = "Ground coffee"},
        new() { Id = "ing_5", Name = "Chocolate"},
        new() { Id = "ing_6", Name = "Black Tea"},
    };

    public static List<Drink> ExampleDrinks => new()
    {
        new() { Id = "drink_1", Name = "Latte", Recipe = "Steam up two cups of the milk with foam and mix it with one cup of espresso" },
        new() { Id = "drink_2", Name = "Cappuccino", Recipe = "A cappuccino is an espresso drink with steamed milk, milk foam and espresso. It’s very similar to a latte (cafe latte), but the proportion of steamed milk is different. A cappuccino has equal parts espresso, steamed milk and foam (⅓ each)." },
        new() { Id = "drink_3", Name = "Espresso", Recipe = "Use espresso roast coffee, about 9 grams for a single espresso shot and 18 grams for a double shot. Grind the coffee until it’s very fine ground. Add the coffee grounds to the espresso basket (portafilter) until it’s slightly heaping over the top. Use the tamper to press the grounds evenly into the portafilter, pressing very firmly until it is fully compressed. Place the portafilter in the espresso machine and press the button to pull the shot." },
        new() { Id = "drink_4", Name = "Black Tea", Recipe = "To make black tea, boil 2 cups of water in a saucepan on a medium flame for 3 minutes. Switch off the flame, add the tea powder, cover it with a lid and keep aside to 3 minutes. Strain immediately using a strainer and discard the tea powder. Serve the black tea immediately." },
        new() { Id = "drink_5", Name = "Cold water", Recipe = "Fill a large cup with water and put 5 piece of ice in it. Let it be for 1 minute and you drink is ready." },
    };

    public static List<DrinksIngredients> ExampleDrinksIngredients => new()
    {
        new () { Id = "drink_ing_1", DrinkId = "drink_1", IngredientId =  "ing_1" },
        new () { Id = "drink_ing_2", DrinkId = "drink_1", IngredientId =  "ing_3" },
        new () { Id = "drink_ing_3", DrinkId = "drink_1", IngredientId =  "ing_4" },
        new () { Id = "drink_ing_4", DrinkId = "drink_2", IngredientId =  "ing_1" },
        new () { Id = "drink_ing_5", DrinkId = "drink_2", IngredientId =  "ing_2" },
        new () { Id = "drink_ing_6", DrinkId = "drink_2", IngredientId =  "ing_4" },
        new () { Id = "drink_ing_7", DrinkId = "drink_2", IngredientId =  "ing_5" },
        new () { Id = "drink_ing_8", DrinkId = "drink_3", IngredientId =  "ing_1" },
        new () { Id = "drink_ing_9", DrinkId = "drink_3", IngredientId =  "ing_4" },
        new () { Id = "drink_ing_10", DrinkId = "drink_4", IngredientId =  "ing_1" },
        new () { Id = "drink_ing_11", DrinkId = "drink_4", IngredientId =  "ing_6" },
        new () { Id = "drink_ing_12", DrinkId = "drink_5", IngredientId =  "ing_1" },
        new () { Id = "drink_ing_13", DrinkId = "drink_5", IngredientId =  "ing_2" },
    };
}