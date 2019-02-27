using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {

    [HttpGet("/restaurants/{restaurantId}/cuisines/new")]
    public ActionResult New(int restaurantId)
    {
     Restaurant restaurant = Restaurant.Find(restaurantId);
     return View(restaurant);
    }

    [HttpGet("/restaurants/{restaurantId}/cuisines/{cuisineId}")]
    public ActionResult Show(int restaurantId, int cuisineId)
    {
      Cuisine item = Cuisine.Find(cuisineId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant restaurant = Restaurant.Find(restaurantId);
      model.Add("cuisine", item);
      model.Add("restaurant", restaurant);
      return View(model);
    }

    [HttpPost("/restaurants/{restaurantId}/cuisines/{cuisineId}/delete")]
    public ActionResult Delete(int restaurantId, int cuisineId)
    {
      Restaurant foundRestaurant = Restaurant.Find(restaurantId);
      Cuisine item = Cuisine.Find(cuisineId);
      item.Delete(cuisineId);
      return View(foundRestaurant);
    }


    [HttpPost("/cuisines/delete")]
    public ActionResult DeleteAll()
    {
      Cuisine.ClearAll();
      return View();
    }

    [HttpGet("/restaurants/{restaurantId}/cuisines/{cuisineId}/edit")]
    public ActionResult Edit(int restaurantId, int cuisineId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant restaurant = Restaurant.Find(restaurantId);
      model.Add("restaurant", restaurant);
      Cuisine item = Cuisine.Find(cuisineId);
      model.Add("cuisine", item);
      return View(model);
    }

    [HttpPost("/restaurants/{restaurantId}/cuisines/{cuisineId}")]
    public ActionResult Update(int restaurantId, int cuisineId, string newType)
    {
      Cuisine item = Cuisine.Find(cuisineId);
      item.Edit(newType);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant restaurant = Restaurant.Find(restaurantId);
      model.Add("restaurant", restaurant);
      model.Add("cuisine", item);
      return View("Show", model);
    }


  }
}
