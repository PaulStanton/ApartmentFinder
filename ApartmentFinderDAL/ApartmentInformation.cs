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
    using System.Collections.Generic;
    
    public partial class ApartmentInformation
    {
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
        public string Picture { get; set; }
    }
}
