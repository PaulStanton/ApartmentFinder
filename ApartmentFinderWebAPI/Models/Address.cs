using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentFinderDAL;

namespace ApartmentFinderWebAPI.Models
{
    public class Address
    {
        private string street_address;
        private string city;
        private string zip;
        private string state;
        public Address()
        {

        }
        public Address(string street_address, string city, string zip, string state)
        {
            this.street_address = street_address;
            this.city = city;
            this.zip = zip;
            this.state = state;

        }
        public string Street_Address { get {return street_address; } set {street_address=value; } }
        public string City { get { return city; } set { city = value; } }
        public string Zip { get { return zip; } set { zip = value; } }
        public string State { get { return state; } set { state = value; } }

    }
}