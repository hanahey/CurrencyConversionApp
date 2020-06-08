using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConversionApp.Models
{
    public class AuditViewModel : IValidatableObject
    {
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public PagedList.IPagedList<AuditRecordViewModel> AuditRecords { get; set; }


        //Input validations for Start Date and End Date
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("End Date must be greater than Start Date.");
            }

            if (StartDate > DateTime.Now.Date)
            {
                yield return new ValidationResult("Start Date must not be after today's date.");
            }

            if (StartDate == null && EndDate !=null)
            {
                yield return new ValidationResult("Start Date is required.");
            }

            if (StartDate !=null && EndDate == null)
            {
                yield return new ValidationResult("End Date is required.");
            }
        }
    }
}