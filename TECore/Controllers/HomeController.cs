using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
using TECore.Models;
using TECore.Utility;
using TECore.Services;
using TECore.Factory;

namespace TECore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOptions<MySettingsModel> appSettings;
        private RatingService ratingService;  
        public HomeController()
        {
            //appSettings = app;
            //ApplicationSettings.WebApiBaseUrl = appSettings.Value.WebApiBaseUrl;
            ratingService = new RatingService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> Ratings()
        {
            var data = await ratingService.GetRatings();
            //var data = await ApiClientFactory.Instance.GetRatings();
            return View(data);
        }
    }
}
