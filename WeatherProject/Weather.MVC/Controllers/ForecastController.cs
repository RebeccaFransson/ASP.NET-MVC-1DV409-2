using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Domain.WebServices;

namespace Weather.MVC.Controllers
{
    public class ForecastController : Controller
    {
        // GET: Forecast
        public ActionResult Index()
        {
            OpenWeatherWebService webbService = new OpenWeatherWebService();
            IEnumerable<Domain.City> city = webbService.GetForecastByCity("malmö");

            return View(city);
        }
    }
}