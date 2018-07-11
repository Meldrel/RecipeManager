using RecipeManager.Model;
using System.Linq;

namespace RecipeManager.Services.Interfaces
{
    public interface IRecipeProvider
    {
        IQueryable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        Recipe AddRecipe(Recipe recipe);
    }
}
