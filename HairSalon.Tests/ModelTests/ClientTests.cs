using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kenny_halim_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test","test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string type = "test";
      string phone = "test";
      Client newClient = new Client(type, phone, 1);

      //Act
      string result = newClient.GetName();

      //Assert
      Assert.AreEqual(type, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string type = "test";
      Client newClient = new Client(type, "test", 1);

      //Act
      string updatedType = "test2";
      newClient.SetName(updatedType);
      string result = newClient.GetName();

      //Assert
      Assert.AreEqual(updatedType, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string description01 = "American";
      string description02 = "English";
      Client newClient1 = new Client(description01, 1);
      newClient1.Save();
      Client newClient2 = new Client(description02, 1);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    
    // [TestMethod]
    // public void Find_ReturnsCorrectClientFromDatabase_Client()
    // {
    //   //Arrange
    //   Client testClient = new Client("American", 1);
    //   testClient.Save();
    //
    //   //Act
    //   Client foundClient = Client.Find(testClient.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(testClient, foundClient);
    // }
    //
    // [TestMethod]
    // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Client()
    // {
    //   // Arrange, Act
    //   Client firstClient = new Client("English", 1);
    //   Client secondClient = new Client("English", 1);
    //
    //   // Assert
    //   Assert.AreEqual(firstClient, secondClient);
    // }
    //
    // [TestMethod]
    // public void Save_SavesToDatabase_ClientList()
    // {
    //   //Arrange
    //   Client testClient = new Client("Chinese", 1);
    //
    //   //Act
    //   testClient.Save();
    //   List<Client> result = Client.GetAll();
    //   List<Client> testList = new List<Client>{testClient};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   //Arrange
    //   Client testClient = new Client("Chinese", 1);
    //
    //   //Act
    //   testClient.Save();
    //   Client savedClient = Client.GetAll()[0];
    //
    //   int result = savedClient.GetId();
    //   int testId = testClient.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesClientInDatabase_String()
    // {
    //   //Arrange
    //   Client testClient = new Client("American", 1);
    //   testClient.Save();
    //   string secondDescription = "English";
    //
    //   //Act
    //   testClient.Edit(secondDescription);
    //   string result = Client.Find(testClient.GetId()).GetTypeOfFood();
    //
    //   //Assert
    //   Assert.AreEqual(secondDescription, result);
    // }
    //
    // [TestMethod]
    // public void Delete_UpdatesClientInDatabase_String()
    // {
    //   //Arrange
    //   Client testClient = new Client("American", 1);
    //   Client testClient2 = new Client("English", 1);
    //   testClient.Save();
    //   testClient2.Save();
    //   testClient.Delete(testClient.GetId());
    //
    //   List<Client> newList = new List<Client> { testClient2 };
    //   List<Client> result = Client.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }

  }
}
