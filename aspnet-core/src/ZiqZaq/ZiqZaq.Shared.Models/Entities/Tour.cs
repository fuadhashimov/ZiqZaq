using System;

namespace ZiqZaq.Shared.Models.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public decimal InfantPrice { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}