using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManager.Model
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }       
        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
