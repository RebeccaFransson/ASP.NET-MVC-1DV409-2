using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Weather.Domain;
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
                    string firstCityName = model.CityName;
                    model.City = _service.GetCity(firstCityName);
                    _service.RefreshWeather(model.City);
                    if(model.City.Name.ToLower() != firstCityName.ToLower())
                    {
                        TempData["error"] = String.Format("Coundnt find {0}, did you mean {1}?", firstCityName, model.City.Name);
                    }

                    int daynr = (int)DateTime.Now.DayOfWeek;
                    while (model.WeekDays.Count() < 5)//antal dagar vi vill blicka framåt med
                    {
                        if (daynr >= 7)//dagar i veckan
                        {
                            daynr = 0;
                        }
                        model.WeekDays.Add(DateTime.Now.AddDays(model.WeekDays.Count()).DayOfWeek.ToString());
                        daynr++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                TempData["error"] = String.Format("This city dosent exist.");
            }
            catch (Exception ex)
            {
                return View("SystemError");
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