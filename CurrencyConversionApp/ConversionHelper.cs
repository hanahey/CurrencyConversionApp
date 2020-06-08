using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyConversionApp
{
    public class ConversionHelper
    {
        public enum Currency
        {
            GBP,
            AUD,
            USD,
            EUR
        }

        private static Dictionary<Tuple<Currency, Currency>, double> CurrencyDictionary = new Dictionary<Tuple<Currency, Currency>, double>
        {
                {  new Tuple<Currency, Currency>(Currency.GBP, Currency.USD), 1.26 },
                {  new Tuple<Currency, Currency>(Currency.GBP, Currency.AUD), 1.81 },
                {  new Tuple<Currency, Currency>(Currency.GBP, Currency.EUR), 1.12 },
                {  new Tuple<Currency, Currency>(Currency.USD, Currency.GBP), 0.79 },
                {  new Tuple<Currency, Currency>(Currency.USD, Currency.AUD), 1.44 },
                {  new Tuple<Currency, Currency>(Currency.USD, Currency.EUR), 0.89 },
                {  new Tuple<Currency, Currency>(Currency.AUD, Currency.GBP), 0.55 },
                {  new Tuple<Currency, Currency>(Currency.AUD, Currency.EUR), 0.62 },
                {  new Tuple<Currency, Currency>(Currency.AUD, Currency.USD), 0.70 },
                {  new Tuple<Currency, Currency>(Currency.EUR, Currency.GBP), 0.89 },
                {  new Tuple<Currency, Currency>(Currency.EUR, Currency.AUD), 1.62 },
                {  new Tuple<Currency, Currency>(Currency.EUR, Currency.USD), 1.13 }
        };

        public static double GetExchangeRate(Currency from, Currency to)
        {
            //if currencyFrom is equal to currencyTo, always return 1
            if (from == to)
                return 1;
            else
            {
                var key = new Tuple<Currency, Currency>(from, to);
                return CurrencyDictionary[key];
            }
        }

        public static string GetCurrencyConversionAbbreviation(Currency from, Currency to)
        {
            string currencyConvertionAbbreviation = from.ToString() + "-" + to.ToString();
            return currencyConvertionAbbreviation;
        }
    }
}