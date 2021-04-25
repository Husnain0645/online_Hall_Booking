using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class HallFacilities
    {
        [Key]
        public int hfacId { get; set; }
        [Required]
        public string Name { get; set; }
       
        public short status { get; set; }
        [Required]
        public DateTime createdAt { get; set; }

        public string createdBy { get; set; }
       
        public string updatedBy { get; set; }

        [ForeignKey("Hall")]
        public int hallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
