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
    
    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            this.Rooms = new HashSet<Room>();
        }
    
        public int ApartmentID { get; set; }
        public string ApartmentName { get; set; }
        public string Street_Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public Nullable<int> CityID { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual City City { get; set; }
    }
}
