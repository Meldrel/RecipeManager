using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManager.Model
{
    public class RecipeIngredient 
    {
        public int Amount { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
