using System;
using NUnit.Framework;
using ApartmentFinderWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentFinderUnitTestProject
{
    [TestClass]
    public class ApartmentFinderTests
    {
        Address address = new Address();

        [TestMethod]
        public void City()
        {
            address.Street_Address = "312 Riverbend Pkwy";
            address.City = "Athens";
            address.State = "Georgia";
            address.Zip = "30605";

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.Street_Address, "312 Riverbend Pkwy");
        }

        [Test]
        public void Test()
        {
            
        }
    }
}
