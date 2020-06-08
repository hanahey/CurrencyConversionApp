using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurrencyConversionApp.Models
{
    public class CurrencyConversionViewModel
    {
        public List <string> Currencies { get; set; }

        [Display(Name ="From")]
        public ConversionHelper.Currency CurrencyFrom { get; set; }

        [Display(Name = "To")]
        public ConversionHelper.Currency CurrencyTo { get; set; }

        [Required]
        [Range(0.01, double.PositiveInfinity, ErrorMessage = "The Amount must be a positive number.")]
        [Display(Name = "Amount To Convert")]
        public double AmountToConvert { get; set; }

        [DisplayFormat(DataFormatString = "{0:#:00}")]
        public double? ConvertedAmount { get; set; }
    }
}