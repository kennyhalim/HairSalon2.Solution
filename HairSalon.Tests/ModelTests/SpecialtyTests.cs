using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kenny_halim_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Specialty.ClearAll();
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("test specialty");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Specialty";
      Specialty newSpecialty = new Specialty(name);

      //Act
      string result = newSpecialty.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyList()
    {
      //Arrange
      string name01 = "Cut Short Hair";
      string name02 = "Cut Long Hair";
      Specialty newSpecialty1 = new Specialty(name01);
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty(name02);
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

      //Act
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsSpecialtyInDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Cut Short Hair");
      testSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }


    [TestMethod]
    public void GetAll_SpecialtysEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Specialty.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
    {
      //Arrange, Act
      Specialty firstSpecialty = new Specialty("Cut Short Hair");
      Specialty secondSpecialty = new Specialty("Cut Short Hair");

      //Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Cut Short Hair");
      testSpecialty.Save();

      //Act
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToSpecialty_Id()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Cut Short Hair");
      testSpecialty.Save();

      //Act
      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Delete_UpdatesSpecialtyInDatabase_String()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("test");
      Specialty testSpecialty2 = new Specialty("test2");
      testSpecialty.Save();
      testSpecialty2.Save();
      testSpecialty2.Delete(testSpecialty2.GetId());
      List<Specialty> newList = new List<Specialty> { testSpecialty };
      List<Specialty> result = Specialty.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetStylists_ReturnsAllSpecialtyStylists_StylistList()
    {
      Specialty testSpecialty = new Specialty("Cut Hair");
      testSpecialty.Save();
      Stylist testStylist1 = new Stylist("Atom");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Atom2");
      testStylist2.Save();
      testSpecialty.AddStylist(testStylist1);
      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist>{testStylist1};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddStylist_AddsStylistToSpecialty_StylistList()
    {
      Specialty newSpecialty = new Specialty("test");
      newSpecialty.Save();
      Stylist testStylist = new Stylist("Atom");
      testStylist.Save();
      newSpecialty.AddStylist(testStylist);
      List<Stylist> result = newSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist>{testStylist};
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
