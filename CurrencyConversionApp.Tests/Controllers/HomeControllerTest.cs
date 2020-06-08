using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConversionApp.Controllers;

namespace CurrencyConversionApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CheckUserLoggedInReturnsFalse()
        {
            //Arrange
            System.Web.HttpContext.Current = null;

            //Act
            HomeController controller = new HomeController();
            var result = controller.CheckUserLoggedIn();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IndexIsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CurrencyConversionIsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.CurrencyConversion() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
