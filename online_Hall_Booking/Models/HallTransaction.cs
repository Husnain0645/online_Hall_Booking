using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class HallTransaction
    {
        [Key]
        public int treId { get; set; }


        [Required]
        public string decription { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime  Date { get; set; }
        public short status { get; set; }

        public hallOrder ordId { get; set; }
        public Hall hId { get; set; }
        public string refId { get; set; }


    }
}
