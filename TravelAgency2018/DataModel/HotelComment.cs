//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAgency2018.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelComment
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int ApplicationId { get; set; }
        public int Author { get; set; }
        public string Text { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual User User { get; set; }
    }
}
