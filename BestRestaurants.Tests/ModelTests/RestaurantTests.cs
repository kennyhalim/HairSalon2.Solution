using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurants.Tests
{
  [TestClass]
  public class RestaurantTest : IDisposable
  {

    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bestrestaurants_test;";
    }

    public void Dispose()
    {
      Restaurant.ClearAll();
      Cuisine.ClearAll();
    }

    [TestMethod]
    public void RestaurantConstructor_CreatesInstanceOfRestaurant_Restaurant()
    {
      Restaurant newRestaurant = new Restaurant("test restaurant");
      Assert.AreEqual(typeof(Restaurant), newRestaurant.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Restaurant";
      Restaurant newRestaurant = new Restaurant(name);

      //Act
      string result = newRestaurant.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetAll_ReturnsAllRestaurantObjects_RestaurantList()
    {
      //Arrange
      string name01 = "Pizza Hut";
      string name02 = "BWW";
      Restaurant newRestaurant1 = new Restaurant(name01);
      newRestaurant1.Save();
      Restaurant newRestaurant2 = new Restaurant(name02);
      newRestaurant2.Save();
      List<Restaurant> newList = new List<Restaurant> { newRestaurant1, newRestaurant2 };

      //Act
      List<Restaurant> result = Restaurant.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsRestaurantInDatabase_Restaurant()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("BWW");
      testRestaurant.Save();

      //Act
      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());

      //Assert
      Assert.AreEqual(testRestaurant, foundRestaurant);
    }

    [TestMethod]
    public void GetItems_ReturnsEmptyItemList_ItemList()
    {
      //Arrange
      string name = "BWW";
      Restaurant newRestaurant = new Restaurant(name);
      List<Cuisine> newList = new List<Cuisine> { };

      //Act
      List<Cuisine> result = newRestaurant.GetCuisines();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_CategoriesEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Restaurant.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Restaurant()
    {
      //Arrange, Act
      Restaurant firstRestaurant = new Restaurant("BWW");
      Restaurant secondRestaurant = new Restaurant("BWW");

      //Assert
      Assert.AreEqual(firstRestaurant, secondRestaurant);
    }

    [TestMethod]
    public void Save_SavesRestaurantToDatabase_RestaurantList()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("BWW");
      testRestaurant.Save();

      //Act
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToRestaurant_Id()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("BWW");
      testRestaurant.Save();

      //Act
      Restaurant savedRestaurant = Restaurant.GetAll()[0];

      int result = savedRestaurant.GetId();
      int testId = testRestaurant.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetItems_RetrievesAllItemsWithRestaurant_ItemList()
    {
      //Arrange, Act
      Restaurant testRestaurant = new Restaurant("Chiangs");
      testRestaurant.Save();
      Cuisine firstCuisine = new Cuisine("Chinese", testRestaurant.GetId());
      firstCuisine.Save();
      Cuisine secondCuisine = new Cuisine("Chinese2", testRestaurant.GetId());
      secondCuisine.Save();
      List<Cuisine> testCuisineList = new List<Cuisine> {firstCuisine, secondCuisine};
      List<Cuisine> resultCuisineList = testRestaurant.GetCuisines();

      //Assert
      CollectionAssert.AreEqual(testCuisineList, resultCuisineList);
    }

  }
}
