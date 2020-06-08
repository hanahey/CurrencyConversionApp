using CurrencyConversionApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyConversionApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //check if there is a user logged in:
        public bool CheckUserLoggedIn()
        {
            return System.Web.HttpContext.Current!= null && 
                   System.Web.HttpContext.Current.User != null && 
                   System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult CurrencyConversion()
        {
            CurrencyConversionViewModel model = new CurrencyConversionViewModel();
            model.Currencies = Enum.GetNames(typeof(ConversionHelper.Currency)).ToList();

            return View(model);
        }

        //POST
        [HttpPost]
        public ActionResult CurrencyConversion(CurrencyConversionViewModel model)
        {
            model.Currencies = Enum.GetNames(typeof(ConversionHelper.Currency)).ToList();

            CurrencyConversion conversionRecord = new CurrencyConversion();

            if (ModelState.IsValid)
            {
                if (CheckUserLoggedIn()) //only save record if there is a user attached to it
                {
                    //get logged in user id:
                    string currentUserId = System.Web.HttpContext.Current.GetOwinContext().
                         GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Id;

                    conversionRecord = new CurrencyConversion
                    {
                        Amount = model.AmountToConvert,
                        CurrencyFrom = model.CurrencyFrom,
                        CurrencyTo = model.CurrencyTo,
                        ExchangeRate = ConversionHelper.GetExchangeRate(model.CurrencyFrom, model.CurrencyTo),
                        Date = DateTime.Now,
                        UserId = currentUserId,
                    };
                    db.CurrencyConversion.Add(conversionRecord);
                    db.SaveChanges();
                }
            }
            //display converted amount
            model.ConvertedAmount = model.AmountToConvert * ConversionHelper.GetExchangeRate(model.CurrencyFrom, model.CurrencyTo);

            return View(model);
        }
    }
}