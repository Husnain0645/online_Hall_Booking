using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class HallTiming
    {
        [Key]
        public int htId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public short status { get; set; }

        [ForeignKey("Hall")]
        public int hallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
