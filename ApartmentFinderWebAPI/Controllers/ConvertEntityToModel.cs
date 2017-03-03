using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL =ApartmentFinderDAL;
using MOD =ApartmentFinderWebAPI.Models;

namespace ApartmentFinderWebAPI.Controllers
{
    public static class ConvertEntityToModel
    {
        public static MOD.User convertuser(DAL.User temp)
        {
            return new MOD.User(temp.FirstName, temp.LastName, temp.Email, temp.Username, temp.Password);
            
        }
        
    }
}