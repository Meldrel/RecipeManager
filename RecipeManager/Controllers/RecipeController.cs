using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Model;
using RecipeManager.Services.Interfaces;
using RecipeManager.ViewModel;

namespace RecipeManager.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeProvider _recipeProvider;

        public RecipeController(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }
       

        public IActionResult Recipes()
        {
            return View(_recipeProvider.GetRecipes());
        }


        public IActionResult Details(int id)
        {
            return View(_recipeProvider.GetRecipe(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecipeViewModel recipeViewModel)
        {
            var recipe = new Recipe();
            recipe.Name = recipeViewModel.Name;
            recipe.Ingredients = new List<RecipeIngredient>();

            recipe = _recipeProvider.AddRecipe(recipe);

            return RedirectToAction(nameof(Details), new { id = recipe.ID });
        }

        public IActionResult Edit(int id)
        {
            return View(_recipeProvider.GetRecipe(id));
        }

        //// GET: Recipe
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Recipe/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Recipe/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Recipe/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Recipe/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Recipe/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Recipe/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Recipe/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}