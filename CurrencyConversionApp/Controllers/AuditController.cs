using CurrencyConversionApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CurrencyConversionApp.Controllers
{
    //user needs to be logged in to view his/her currency conversion record
    [Authorize]
    public class AuditController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //GET
        //default table will show ALL of the user's records before filter
        public ActionResult Index(int? page)
        {
            //set pagination attributes
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            AuditViewModel model = new AuditViewModel();
            var auditRecords = new List<AuditRecordViewModel>();

            //get logged in user id
            string currentUserId = System.Web.HttpContext.Current.GetOwinContext().
                 GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;

            //Retrieve any filters when the page is changed
            if (TempData.ContainsKey("filteredAuditRecordsStartDate") || TempData.ContainsKey("filteredAuditRecordsEndDate"))
            {
                model.StartDate = (DateTime)TempData.Peek("filteredAuditRecordsStartDate");
                model.EndDate = (DateTime)TempData.Peek("filteredAuditRecordsEndDate");
            }

            //get all of the user's records
            var query = db.CurrencyConversion.Where(c => c.UserId == currentUserId);

            //check if there is a date filter selected
            if (model.StartDate.HasValue && model.EndDate.HasValue)
            {
                var startDate = model.StartDate.Value.Date;
                var endDate = model.EndDate.Value.Date.AddHours(24); //ensure that all records for the specified end date are returned

                //refine query according to date range selected
                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
            }

            //get records from query and put into the view model
            auditRecords = query.OrderByDescending(x => x.Date).Select(c =>
                        new AuditRecordViewModel
                        {
                            Id = c.Id,
                            Amount = c.Amount,
                            CurrencyFrom = c.CurrencyFrom,
                            CurrencyTo = c.CurrencyTo,
                            ExchangeRate = c.ExchangeRate,
                            Date = c.Date,
                        }).ToList();

            //get currency conversion abbreviations for all records
            auditRecords.ForEach(c => c.Currency = ConversionHelper.GetCurrencyConversionAbbreviation(c.CurrencyFrom, c.CurrencyTo));

            //place the audit records into the view model's paged list of audit records for pagination purposes
            model.AuditRecords = auditRecords.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        //POST
        [HttpPost]
        public ActionResult Index(int? page, AuditViewModel model)
        {
            //set pagination attributes
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            //get logged in user id:
            string currentUserId = System.Web.HttpContext.Current.GetOwinContext().
                 GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;

            var query = db.CurrencyConversion.Where(c => c.UserId == currentUserId);

            //save date filters in TempData for use for when the page is changed
            if (model.StartDate != null && model.EndDate != null)
            {
                TempData["filteredAuditRecordsStartDate"] = model.StartDate;
                TempData["filteredAuditRecordsEndDate"] = model.EndDate;

                var startDate = model.StartDate.Value.Date;
                var endDate = model.EndDate.Value.Date.AddHours(24); //ensure that all records for the specified end date are returned

                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
            }

            var auditRecords = query.OrderByDescending(x => x.Date).Select(c =>
                        new AuditRecordViewModel
                        {
                            Id = c.Id,
                            Amount = c.Amount,
                            CurrencyFrom = c.CurrencyFrom,
                            CurrencyTo = c.CurrencyTo,
                            ExchangeRate = c.ExchangeRate,
                            Date = c.Date,
                        }).ToList();

            //get currency conversion abbreviations for all records
            auditRecords.ForEach(c => c.Currency = ConversionHelper.GetCurrencyConversionAbbreviation(c.CurrencyFrom, c.CurrencyTo));

            //place the audit records into the view model's paged list of audit records for pagination purposes
            model.AuditRecords = auditRecords.ToPagedList(pageNumber, pageSize);

            return View(model);
        }
    }
}
