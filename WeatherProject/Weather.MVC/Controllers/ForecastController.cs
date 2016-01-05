using System;
using System.Collections.Generic;
using System.Linq;
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
                    model.City = _service.GetCity(model.CityName);
                    _service.RefreshWeather(model.City);
                }
                /*
                OpenWeatherWebService webbService = new OpenWeatherWebService();
                IEnumerable<Domain.City> city = webbService.GetForecastByCity("malmö");

                return View(city);
                */
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View(model);
        }
    }
}