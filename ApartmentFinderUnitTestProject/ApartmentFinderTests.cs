using System;
using NUnit.Framework;
using ApartmentFinderWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentFinderUnitTestProject
{
    [TestClass]
    public class ApartmentFinderTests
    {
        [TestMethod]
        public void City()
        {
            Address address = new Address();
            address.Street_Address = "312 Riverbend Pkwy";

        }
    }
}
