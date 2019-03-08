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
      Client newClient = new Client("test","test");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string type = "test";
      string phone = "test";
      Client newClient = new Client(type, phone);

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
      Client newClient = new Client(type, "test");

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
      string name01 = "test";
      string name02 = "test";
      Client newClient1 = new Client(name01, "test");
      newClient1.Save();
      Client newClient2 = new Client(name02, "test");
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("test", "test");
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("test", "test");
      Client secondClient = new Client("test", "test");

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("test", "test");

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("test", "test");

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("test", "test");
      testClient.Save();
      string secondName = "test2";

      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.GetId()).GetName();

      //Assert
      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void Delete_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("test", "test");
      Client testClient2 = new Client("test2", "test");
      testClient.Save();
      testClient2.Save();
      testClient2.Delete(testClient2.GetId());
      List<Client> newList = new List<Client> { testClient };
      List<Client> result = Client.GetAll();


      CollectionAssert.AreEqual(newList, result);
    }

  }
}
