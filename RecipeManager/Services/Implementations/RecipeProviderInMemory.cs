using RecipeManager.Model;
using RecipeManager.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager.Services.Implementations
{
    public class RecipeProviderInMemory : IRecipeProvider
    {
        private List<Recipe> _recipes;

        public RecipeProviderInMemory()
        {
            var pasta = new Ingredient() { ID = 1, Name = "Pasta" };
            var tomate = new Ingredient() { ID = 2, Name = "Tomate" };
            var aceite = new Ingredient() { ID = 3, Name = "Aceite" };

            _recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    ID = 1,
                    Name = "Pasta a la boloñesa",
                    Ingredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient()
                        {
                            Amount = 100,
                            Ingredient = pasta
                        },
                        new RecipeIngredient()
                        {
                            Amount = 2,
                            Ingredient = tomate
                        }
                    }
                },
                new Recipe()
                {
                    ID =2,
                    Name = "Ensalada de tomate",
                    Ingredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient()
                        {
                            Amount = 100,
                            Ingredient = aceite
                        },
                        new RecipeIngredient()
                        {
                            Amount = 2,
                            Ingredient = tomate
                        }
                    }
                }
            };

            
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            recipe.ID = _recipes.Max(x => x.ID) + 1;
            _recipes.Add(recipe);

            return recipe;
        }

        public Recipe GetRecipe(int id)
        {
            return _recipes.First(x => x.ID == id);
        }

        public IQueryable<Recipe> GetRecipes()
        {
            return _recipes.AsQueryable();
        }
    }
}
