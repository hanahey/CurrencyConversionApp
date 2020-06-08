using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConversionApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConversionApp.Tests.Models
{
    [TestClass]
    public class AuditViewModelTest
    {
        [TestMethod]
        public void EndDateMustBeAfterStartDateErrorMessageIsDisplayed()
        {
            // Arrange
            var startDate = new DateTime(2020, 5, 11);
            var endDate = new DateTime(2020, 3, 1);
            var errorMessage = "End Date must be greater than Start Date.";

            var model = new AuditViewModel
            {
                StartDate = new DateTime(2020, 5, 11),
                EndDate = new DateTime(2020, 3, 1),
            };

            // Act
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject
                          (model, new ValidationContext(model), result);


            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(errorMessage, result[0].ErrorMessage);
        }

        [TestMethod]
        public void StartDateMustNotBeAfterTodaysDateErrorMessageIsDisplayed()
        {
            // Arrange
            var errorMessage = "Start Date must not be after today's date.";

            var model = new AuditViewModel
            {
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddDays(10),
            };

            // Act
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject
                          (model, new ValidationContext(model), result);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(errorMessage, result[0].ErrorMessage);
        }

        [TestMethod]
        public void StartDateIsRequiredErrorMessageIsDisplayed()
        {
            // Arrange
            var errorMessage = "Start Date is required.";

            var model = new AuditViewModel
            {
                StartDate = null,
                EndDate = DateTime.Now.AddDays(10),
            };

            // Act
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject
                          (model, new ValidationContext(model), result);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(errorMessage, result[0].ErrorMessage);
        }

        [TestMethod]
        public void EndDateIsRequiredErrorMessageIsDisplayed()
        {
            // Arrange
            var errorMessage = "End Date is required.";

            var model = new AuditViewModel
            {
                StartDate = new DateTime(2019,12,22),
                EndDate = null
            };

            // Act
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject
                          (model, new ValidationContext(model), result);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(errorMessage, result[0].ErrorMessage);
        }
    }
}
