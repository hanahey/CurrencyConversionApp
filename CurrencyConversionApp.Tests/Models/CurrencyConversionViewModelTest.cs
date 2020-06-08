using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyConversionApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConversionApp.Tests.Models
{
    [TestClass]
    public class CurrencyConversionViewModelTest

    {
        [TestMethod]
        public void AmountToConvertRangeErrorMessageIsDisplayed()
        {
            // Arrange
            var invalidAmountToConvert = -1000.34;
            var errorMessage = "The Amount must be a positive number.";

            // Act
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(invalidAmountToConvert,
                          new ValidationContext(new CurrencyConversionViewModel())
                          { MemberName = "AmountToConvert" }, result);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(errorMessage, result[0].ErrorMessage);
        }
    }
}
