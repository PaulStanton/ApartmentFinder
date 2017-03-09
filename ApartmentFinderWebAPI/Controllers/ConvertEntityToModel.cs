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
        
        public static MOD.Address convertApartmentAddress(DAL.Apartment temp)
        {
            return new MOD.Address(temp.Street_Address,temp.City.Name,temp.City.Zip_Code,temp.City.State.StateName);
        }

        public static MOD.Room convertRoom(DAL.Room temp)
        {
            return new MOD.Room((int)temp.NumberOfBeds,(int) temp.NumberOfBaths, temp.RoomNumber, temp.isFilled, (double)temp.price, temp.Picture);
        }
        public static MOD.Apartment convertApartment(DAL.Apartment temp)
        {
            List<MOD.Room> tempRooms = new List<MOD.Room>();
            foreach (var item in temp.Rooms)
            {
                tempRooms.Add(convertRoom(item));
            }
            return new MOD.Apartment(temp.ApartmentName, temp.ContactEmail, temp.ContactPhone, temp.Picture, convertApartmentAddress(temp), tempRooms);
        }

        
    }
}