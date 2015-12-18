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
            var webbService = new OpenWeatherWebService();
            var city = webbService.GetForecastByCity("kalmar");

            return View();
        }
    }
}