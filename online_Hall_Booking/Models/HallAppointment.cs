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

        public sbyte Status { get; set; }

        [NotMapped]
        public double perheadCharges { get; set; }
        public double Persons { get; set; }
        public double AdvancedAmount { get; set; }
        public double RemaingAmount { get; set; }
        public double TotalAmount { get; set; }

        public string createdBy { get; set; }

        public string updatedBy { get; set; }


        public int? PId { get; set; }
        [ForeignKey("PId")]
        public HallPackages Package { get; set; }

        public int HId { get; set; }
        [ForeignKey("HId")]
        public  Hall Hall{ get; set; }
    }
}
