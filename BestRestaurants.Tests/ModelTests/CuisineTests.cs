using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurants.Tests
{
  [TestClass]
  public class CuisineTest : IDisposable
  {

    public void Dispose()
    {
      Cuisine.ClearAll();
    }

    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bestrestaurants_test;";
    }

    [TestMethod]
    public void CuisineConstructor_CreatesInstanceOfCuisine_Cuisine()
    {
      Cuisine newCuisine = new Cuisine("test", 1);
      Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string type = "American";
      Cuisine newCuisine = new Cuisine(type, 1);

      //Act
      string result = newCuisine.GetTypeOfFood();

      //Assert
      Assert.AreEqual(type, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string type = "English";
      Cuisine newCuisine = new Cuisine(type, 1);

      //Act
      string updatedType = "American";
      newCuisine.SetTypeOfFood(updatedType);
      string result = newCuisine.GetTypeOfFood();

      //Assert
      Assert.AreEqual(updatedType, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_CuisineList()
    {
      //Arrange
      List<Cuisine> newList = new List<Cuisine> { };

      //Act
      List<Cuisine> result = Cuisine.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsCuisines_CuisineList()
    {
      //Arrange
      string description01 = "American";
      string description02 = "English";
      Cuisine newCuisine1 = new Cuisine(description01, 1);
      newCuisine1.Save();
      Cuisine newCuisine2 = new Cuisine(description02, 1);
      newCuisine2.Save();
      List<Cuisine> newList = new List<Cuisine> { newCuisine1, newCuisine2 };

      //Act
      List<Cuisine> result = Cuisine.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCuisineFromDatabase_Cuisine()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("American", 1);
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());

      //Assert
      Assert.AreEqual(testCuisine, foundCuisine);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Cuisine()
    {
      // Arrange, Act
      Cuisine firstCuisine = new Cuisine("English", 1);
      Cuisine secondCuisine = new Cuisine("English", 1);

      // Assert
      Assert.AreEqual(firstCuisine, secondCuisine);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CuisineList()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Chinese", 1);

      //Act
      testCuisine.Save();
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Chinese", 1);

      //Act
      testCuisine.Save();
      Cuisine savedCuisine = Cuisine.GetAll()[0];

      int result = savedCuisine.GetId();
      int testId = testCuisine.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesCuisineInDatabase_String()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("American", 1);
      testCuisine.Save();
      string secondDescription = "English";

      //Act
      testCuisine.Edit(secondDescription);
      string result = Cuisine.Find(testCuisine.GetId()).GetTypeOfFood();

      //Assert
      Assert.AreEqual(secondDescription, result);
    }

    [TestMethod]
    public void Delete_UpdatesCuisineInDatabase_String()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("American", 1);
      Cuisine testCuisine2 = new Cuisine("English", 1);
      testCuisine.Save();
      testCuisine2.Save();
      testCuisine.Delete(testCuisine.GetId());

      List<Cuisine> newList = new List<Cuisine> { testCuisine2 };
      List<Cuisine> result = Cuisine.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

  }
}
