using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurrencyConversionApp.Models
{
    public class AuditRecordViewModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public ConversionHelper.Currency CurrencyFrom { get; set; }

        public ConversionHelper.Currency CurrencyTo { get; set; }

        [Display(Name = "Exchange Rate")]
        public double ExchangeRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}