using Microsoft.VisualStudio.TestTools.UnitTesting;
using TECore.Services;

namespace TECoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetRatings()
        {
           var rs = new RatingService();
            var data = rs.GetRatings().Result;
        }
    }
}
