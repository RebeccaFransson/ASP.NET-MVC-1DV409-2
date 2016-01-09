using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather.Domain;
using Weather.Domain.WebServices;
using Weather.MVC.ViewModels;

namespace Weather.MVC.Controllers
{
    public class ForecastController : Controller
    {
        private IOpenWeatherService _service;

#region constructiors
        public ForecastController()
            :this(new OpenWeatherService())
        {
            //tom!
        }
        public ForecastController(IOpenWeatherService service)
        {
            _service = service;
        }
#endregion

        public ActionResult Index()
        {
            return View();
        }
        // GET: Forecast
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CityName")] ForecastViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.WeekDays = new List<string>(5);

                    model.City = _service.GetCity(model.CityName);
                    _service.RefreshWeather(model.City);


                    string[] days = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                    int daynr = Array.IndexOf(days, DateTime.Now.DayOfWeek.ToString());
                    while (model.WeekDays.Count() < 5)//antal dagar vi vill blicka framåt med
                    {
                        if (daynr >= days.Count())
                        {
                            daynr = 0;
                        }
                        model.WeekDays.Add(days[daynr]);
                        daynr++;
                    }
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["error"] = String.Format("This city dosent exist. {0}", ex);
            }
            return View(model);
        }



        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}