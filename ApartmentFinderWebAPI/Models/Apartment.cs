using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentFinderDAL;
namespace ApartmentFinderWebAPI.Models
{
    public class Apartment
    {
        Address apartment_address = new Address();
        List<Room> roomList = new List<Room>();
        private string apartmentname;
        private string contactemail;
        private string contactphone;
        private string pictureURL;
        private int apartmentid;
        public Apartment()
        {

        }
        public Apartment(int apartmentid,string apartmentname, string contactEmail, string contactphone, string pictureURL, Address apartment_address, List<Room> roomList)
        {
            this.apartmentid = apartmentid;
            this.apartmentname = apartmentname;
            this.contactemail = contactEmail;
            this.contactphone = contactphone;
            this.pictureURL = pictureURL;
            this.apartment_address = apartment_address;
            this.roomList = roomList;
        }
        public int ApartmentID { get { return apartmentid; } set { apartmentid = value; } }
        public string PictureURL { get { return pictureURL; } set {pictureURL=value; } }
        public string ContactPhone { get {return contactphone; } set { contactphone = value; } }
        public string ContactEmail { get { return contactemail; } set { contactemail = value; } }
        public string ApartmentName { get { return apartmentname; } set {apartmentname=value; } }
        public Address Apartment_Address { get { return apartment_address; } set { apartment_address = value; } }
        public List<Room> RoomList { get { return roomList; } set { roomList = value; } }

    }
}