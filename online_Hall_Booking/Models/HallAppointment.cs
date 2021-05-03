using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class HallAppointment
    {
        [Key]
        public int HapId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string Email { get; set; }

        public string Remarks { get; set; }

        public string AdminRemarks { get; set; }

        public String Date { get; set; }

        public byte Status { get; set; }

        public int HId { get; set; }
        [ForeignKey("HId")]
        public  Hall Hall{ get; set; }
    }
}
