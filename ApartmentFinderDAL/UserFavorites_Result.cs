//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApartmentFinderDAL
{
    using System;
    
    public partial class UserFavorites_Result
    {
        public int UserID { get; set; }
        public string firstname { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int RoomID { get; set; }
        public Nullable<int> NumberOfBeds { get; set; }
        public string RoomNumber { get; set; }
        public bool isFilled { get; set; }
        public Nullable<decimal> price { get; set; }
        public string Picture { get; set; }
        public int ApartmentID { get; set; }
        public string ApartmentName { get; set; }
        public string Street_Address { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Zip_Code { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ApartmentPicture { get; set; }
    }
}
