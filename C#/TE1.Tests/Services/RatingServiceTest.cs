using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TE1.Services;
using TE1.Models.Responses;


namespace TE1.Tests.Services
{
    [TestClass]
    public class RatingServiceTest
    {
        [TestMethod]
        public void GetRatingForCountry()
        {
            RatingService rs = new RatingService();
            var rr = rs.GetRatingForCountry("croatia");
        }
        [TestMethod]
        public void GetRatingForCountries()
        {
            RatingService rs = new RatingService();
            string[] countries = new string[] { "croatia","slovenia" };
            var rr = rs.GetRatingForCountries(countries);
        }
        [TestMethod]
        public void GetHistoricalRatings()
        {
            RatingService rs = new RatingService();
            string[] countries = new string[] { "croatia", "slovenia","nigeria" };
            var rr = rs.GetHistoricalRatings(countries);
        }
    }
}
