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
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.Application = new HashSet<Application>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Hotels { get; set; }
        public int TicketsCount { get; set; }
        public decimal Price { get; set; }
        public bool IsActual { get; set; }
        public string TourTypes { get; set; }
        public string ImagePreview { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Application { get; set; }
        public virtual Country Country1 { get; set; }
    }
}
