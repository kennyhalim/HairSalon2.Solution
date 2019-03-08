using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest
    {
      [TestMethod]
      public void DeleteAll_ReturnsCorrectView_True()
      {
        //Arrange
        SpecialtiesController controller = new SpecialtiesController();

        //Act
        ActionResult indexView = controller.DeleteAll();

        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

    }
}
