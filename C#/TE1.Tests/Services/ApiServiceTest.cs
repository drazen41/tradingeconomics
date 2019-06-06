using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TE1.Services;

namespace TE1.Tests.Services
{
    [TestClass]
    public class ApiServiceTest
    {
        [TestMethod]
        public void BrainsDataTest()
        {
            var data = ApiService.BrainsData("").Result;

        }
    }
}
