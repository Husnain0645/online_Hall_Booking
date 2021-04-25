
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class HallPackages
    {
        [Key]
        public int pId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string decription { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        [Required]
        public double   personCount { get; set; }
        [Required]
        public double charges { get; set; }
        [Required]
        public string type { get; set; }

        public short status { get; set; }

        [ForeignKey("Hall")]
        public int hallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
