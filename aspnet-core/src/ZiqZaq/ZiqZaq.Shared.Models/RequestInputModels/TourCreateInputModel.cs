using System;
using System.ComponentModel.DataAnnotations;

namespace ZiqZaq.Shared.Models.RequestInputModels
{
    public class TourCreateInputModel
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string DepartureLocation { get; set; }

        [Required]
        [MaxLength(256)]
        public string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public decimal AdultPrice { get; set; }

        public decimal ChildPrice { get; set; }

        public decimal InfantPrice { get; set; }

        public string Description { get; set; }
    }
}
