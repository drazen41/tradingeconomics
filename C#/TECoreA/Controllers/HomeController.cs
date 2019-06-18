using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECore.Services;

namespace TECoreA.Controllers
{
    public class HomeController : Controller
    {
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
            var data = await ratingService.GetRatingsAsync();
            //var data = await ApiClientFactory.Instance.GetRatings();
            return View(data);
        }
    }
}
