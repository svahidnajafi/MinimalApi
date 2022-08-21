USE [MinimalApi_DB]
GO
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_1', N'Water')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_2', N'Ice')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_3', N'Milk')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_4', N'Ground coffee')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_5', N'Chocolate')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (N'ing_6', N'Black Tea')

INSERT [dbo].[Drinks] ([Id], [Name], [Recipe]) VALUES (N'drink_1', N'Latte', N'Steam up two cups of the milk with foam and mix it with one cup of espresso')
INSERT [dbo].[Drinks] ([Id], [Name], [Recipe]) VALUES (N'drink_2', N'Cappuccino', N'A cappuccino is an espresso drink with steamed milk, milk foam and espresso. It’s very similar to a latte (cafe latte), but the proportion of steamed milk is different. A cappuccino has equal parts espresso, steamed milk and foam (⅓ each).')
INSERT [dbo].[Drinks] ([Id], [Name], [Recipe]) VALUES (N'drink_3', N'Espresso', N'Use espresso roast coffee, about 9 grams for a single espresso shot and 18 grams for a double shot. Grind the coffee until it’s very fine ground. Add the coffee grounds to the espresso basket (portafilter) until it’s slightly heaping over the top. Use the tamper to press the grounds evenly into the portafilter, pressing very firmly until it is fully compressed. Place the portafilter in the espresso machine and press the button to pull the shot.')
INSERT [dbo].[Drinks] ([Id], [Name], [Recipe]) VALUES (N'drink_4', N'Black Tea', N'To make black tea, boil 2 cups of water in a saucepan on a medium flame for 3 minutes. Switch off the flame, add the tea powder, cover it with a lid and keep aside to 3 minutes. Strain immediately using a strainer and discard the tea powder. Serve the black tea immediately.')
INSERT [dbo].[Drinks] ([Id], [Name], [Recipe]) VALUES (N'drink_5', N'Cold water', N'Fill a large cup with water and put 5 piece of ice in it. Let it be for 1 minute and you drink is ready.')
    
-- Latte
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_1', N'drink_1', N'ing_1')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_2', N'drink_1', N'ing_3')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_3', N'drink_1', N'ing_4')

-- Cappuccino
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_4', N'drink_2', N'ing_1')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_5', N'drink_2', N'ing_2')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_6', N'drink_2', N'ing_4')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_7', N'drink_2', N'ing_5')

-- Espresso
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_8', N'drink_3', N'ing_1')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_9', N'drink_3', N'ing_4')

-- Black Tea
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_10', N'drink_4', N'ing_1')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_11', N'drink_4', N'ing_6')
    
-- Cold Water
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_12', N'drink_5', N'ing_1')
INSERT [dbo].[DrinksIngredients] ([Id], [DrinkId], [IngredientId]) VALUES (N'drink_ing_13', N'drink_5', N'ing_2')