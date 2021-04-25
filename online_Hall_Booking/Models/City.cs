using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class City
    {
        [Key]
        public int cId { get; set; }
        [Required]
        public string Name { get; set; }
        public short status { get; set; }
    }
}
