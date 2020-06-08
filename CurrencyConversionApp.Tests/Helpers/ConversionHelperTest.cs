using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConversionApp.Tests.Helpers
{
    [TestClass]
    public class ConversionHelperTest
    {
        public ConversionHelperTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void GetExchangeRateReturnsValue()
        {
            //Arrange
            var currencyFrom = ConversionHelper.Currency.GBP;
            var currencyTo = ConversionHelper.Currency.AUD;

            //Act
            var result = ConversionHelper.GetExchangeRate(currencyFrom, currencyTo);

            //Assert
            Assert.AreEqual(1.81, result);
        }

        [TestMethod]
        //test that if currencyFrom == currency to, the exchange rate value returned will be 1:
        public void GetExchangeRateReturnsOne()
        {
            //Arrange
            var currencyFrom = ConversionHelper.Currency.GBP;
            var currencyTo = ConversionHelper.Currency.GBP;

            //Act
            var result = ConversionHelper.GetExchangeRate(currencyFrom, currencyTo);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetCurrencyConversionAbbreviationReturnsCorrectAbbreviation()
        {
            //Arrange
            var currencyFrom = ConversionHelper.Currency.GBP;
            var currencyTo = ConversionHelper.Currency.EUR;

            //Act
            var result = ConversionHelper.GetCurrencyConversionAbbreviation(currencyFrom, currencyTo);

            //Assert
            Assert.AreEqual("GBP-EUR", result);
        }
    }
}
