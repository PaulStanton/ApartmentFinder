using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentFinderWebAPI.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string first, string last, string em, string un, string pass)
        {
            firstname = first;
            lastname = last;
            email = em;
            username = un;
            password = pass;
        }
        public string firstname;
        public string lastname;
        public string email;
        public string username;
        public string password;
    }
}