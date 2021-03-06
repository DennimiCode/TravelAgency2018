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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public partial class TravelAgencyEntities : DbContext
    {
        private static TravelAgencyEntities _context;
        public TravelAgencyEntities()
            : base("name=TravelAgencyEntities")
        {
        }

        public static TravelAgencyEntities GetContext()
        {
            if (_context == null)
                _context = new TravelAgencyEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<FoodServiceType> FoodServiceType { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelComment> HotelComment { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourHistory> TourHistory { get; set; }
        public virtual DbSet<TourType> TourType { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
