using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {

    [HttpGet("/restaurants")]
    public ActionResult Index()
    {
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View(allRestaurants);
    }

    [HttpGet("/restaurants/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/restaurants")]
    public ActionResult Create(string restaurantName)
    {
      Restaurant newRestaurant = new Restaurant(restaurantName);
      newRestaurant.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/restaurants/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant selectedRestaurant = Restaurant.Find(id);
      List<Cuisine> restaurantCuisines = selectedRestaurant.GetCuisines();
      model.Add("restaurant", selectedRestaurant);
      model.Add("cuisines", restaurantCuisines);
      return View(model);
    }

    [HttpPost("/restaurants/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Restaurant selectedRestaurant = Restaurant.Find(id);
      selectedRestaurant.Delete(id);
      return RedirectToAction("Index");
    }

    //This one creates new Items within a given Category, not new Categories:
    [HttpPost("/restaurants/{restaurantId}/cuisines")]
    public ActionResult Create(int restaurantId, string cuisineFood)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant foundRestaurant = Restaurant.Find(restaurantId);
      Cuisine newCuisine = new Cuisine(cuisineFood, restaurantId);
      newCuisine.Save();
      List<Cuisine> restaurantCuisines = foundRestaurant.GetCuisines();
      model.Add("cuisines", restaurantCuisines);
      model.Add("restaurant", foundRestaurant);
      return View("Show", model);
    }

  }
}
