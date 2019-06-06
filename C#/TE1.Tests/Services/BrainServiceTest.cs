using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TE1.Services;

namespace TE1.Tests.Services
{
    [TestClass]
    public class BrainServiceTest
    {
        [TestMethod]
        public void GetEmptyBrainsResponse()
        {
            BrainService bs = new BrainService();
            var data = bs.GetBrainsResponse("");
        }
    }
}
