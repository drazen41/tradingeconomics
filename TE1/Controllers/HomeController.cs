using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TE1.Services;

namespace TE1.Controllers
{
    public class HomeController : Controller
    {
        public RatingService RatingService = null;
        public HomeController()
        {
            RatingService = new RatingService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HistoricalRatings()
        {
            string[] countries = new string[] { "croatia", "slovenia"};
            var model = RatingService.GetHistoricalRatings(countries).OrderBy(x=>x.Country).ThenByDescending(x=>x.Date).ToList();
            return View("HistoricalRatings", model);
        }
        public ActionResult HitsResponse()
        {
            BrainService bs = new BrainService();
            var model = bs.GetHitsResponse("");
            return View("HitsResponse", model);
        }
    }
}