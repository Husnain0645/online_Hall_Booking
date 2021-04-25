using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class hallOrder
    {

        [Key]
        public int ordId { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        [Required]
        public double personCount { get; set; }
        [Required]
        public double totalAmount { get; set; }
        [Required]
        public double receivedAmount { get; set; }
        public double Discount { get; set; }
        [Required]
        public string type { get; set; }

        public short status { get; set; }
        
        public HallPackages PackagesId { get; set; }


        [ForeignKey("hallId")]
        public int hallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
