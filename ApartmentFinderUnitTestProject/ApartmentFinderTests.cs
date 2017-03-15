using System;
using NUnit.Framework;
using ApartmentFinderWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentFinderUnitTestProject
{
    [TestClass]
    public class ApartmentFinderTests
    {
        Address address = new Address("312 Riverbend Pkwy", "Athens", "30605", "Georgia");

        Apartment apartment = new Apartment(3, "Surrey Square", "greensproperties@gmail.com", "706-555-5555", "b", new Address(), null);

        [TestMethod]
        public void ApartmentRd()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.Street_Address, "312 Riverbend Pkwy");
        }

        [TestMethod]
        public void CorrectApartmentStateWithNotEqual()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(address.State, "Georgia");
        }

        [TestMethod]
        public void CorrectApartmentStateWithEqual()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.State, "Georgia");
        }

        [TestMethod]
        public void ApartmentZip()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.Zip, "30605");
        }

        [TestMethod]
        public void FalseApartmentCity()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.City, "Brooklyn");
        }

        [TestMethod]
        public void CorrectApartmentCity()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(address.City, "Athens");
        }

        [TestMethod]
        public void CorrectApartmentName()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(apartment.ApartmentName, "Surrey Square");
        }

        [TestMethod]
        public void CorrectApartmentNameSetToNotEqual()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(apartment.ApartmentName, "Surrey Square");
        }

        [TestMethod]
        public void IncorrectApartmentName()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(apartment.ApartmentName, "The Slums");
        }
    }
}
