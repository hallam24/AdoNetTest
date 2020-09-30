using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdoForm;
using AdoForm.Controllers;
using AdoForm.Models;

namespace AdoTests.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        // Basic checks. Further checks hindered by need for sql connection in data layer
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewData["Title"], "Home");
        }
        // 
        [TestMethod]
        public void CreateUser()
        {
            
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.CreateUser() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewData["Title"], "CreateUser");
        }
    }
}
