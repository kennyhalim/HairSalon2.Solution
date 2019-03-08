using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kenny_halim_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("test stylist");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Stylist";
      Stylist newStylist = new Stylist(name);

      //Act
      string result = newStylist.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
      //Arrange
      string name01 = "Alex";
      string name02 = "Atom";
      Stylist newStylist1 = new Stylist(name01);
      newStylist1.Save();
      Stylist newStylist2 = new Stylist(name02);
      newStylist2.Save();
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

      //Act
      List<Stylist> result = Stylist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Alex");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }


    [TestMethod]
    public void GetAll_StylistsEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Alex");
      Stylist secondStylist = new Stylist("Alex");

      //Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Alex");
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      //Arrange
      Stylist testStylist = new Stylist("Alex");
      testStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Delete_DeletesStylistAssociationsFromDatabase_StylistList()
    {
      Client testClient = new Client("Alex","test");
      testClient.Save();
      string testName = "Atom";
      Stylist testStylist = new Stylist(testName);
      testStylist.Save();
      testStylist.AddClient(testClient);
      testStylist.Delete(testStylist.GetId());
      List<Stylist> resultClientStylists = testClient.GetStylists();
      List<Stylist> testClientStylists = new List<Stylist> {};
      CollectionAssert.AreEqual(resultClientStylists, resultClientStylists);
    }

    [TestMethod]
    public void Test_AddClient_AddsClientToStylist()
    {
      Stylist testStylist = new Stylist("Atom");
      testStylist.Save();
      Client testClient = new Client("Alex", "test");
      testClient.Save();
      Client testClient2 = new Client("Test", "test");
      testClient2.Save();
      testStylist.AddClient(testClient);
      testStylist.AddClient(testClient2);
      List<Client> result = testStylist.GetClients();
      List<Client> testList = new List<Client>{testClient, testClient2};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetClients_ReturnAllStylistClient_ClientList()
    {
      Stylist testStylist = new Stylist("Atom");
      testStylist.Save();
      Client testClient1 = new Client("Alex", "test");
      testClient1.Save();

      testStylist.AddClient(testClient1);
      List<Client> savedClients = testStylist.GetClients();
      List<Client> testList = new List<Client> {testClient1};
      CollectionAssert.AreEqual(testList, savedClients);
    }

    [TestMethod]
    public void Test_AddSpecialty_AddsSpecialtyToStylist()
    {
      Stylist testStylist = new Stylist("Atom");
      testStylist.Save();
      Specialty testSpecialty = new Specialty("test");
      testSpecialty.Save();
      Specialty testSpecialty2 = new Specialty("test");
      testSpecialty2.Save();
      testStylist.AddSpecialty(testSpecialty);
      testStylist.AddSpecialty(testSpecialty2);
      List<Specialty> result = testStylist.GetSpecialties();
      List<Specialty> testList = new List<Specialty>{testSpecialty, testSpecialty2};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetSpecialtys_ReturnAllStylistSpecialty_SpecialtyList()
    {
      Stylist testStylist = new Stylist("Atom");
      testStylist.Save();
      Specialty testSpecialty1 = new Specialty("test");
      testSpecialty1.Save();

      testStylist.AddSpecialty(testSpecialty1);
      List<Specialty> savedSpecialtys = testStylist.GetSpecialties();
      List<Specialty> testList = new List<Specialty> {testSpecialty1};
      CollectionAssert.AreEqual(testList, savedSpecialtys);
    }
  }
}
