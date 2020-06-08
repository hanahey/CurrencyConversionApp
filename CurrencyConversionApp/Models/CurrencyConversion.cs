namespace CurrencyConversionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class CurrencyConversion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public ConversionHelper.Currency CurrencyFrom { get; set; }

        [Required]
        public ConversionHelper.Currency CurrencyTo { get; set; }

        [Required]
        public double ExchangeRate { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(128)]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
