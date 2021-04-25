using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class Country
    {

        [Key]
        public int couId { get; set; }
        [Required]
        public string Name { get; set; }
        public short status { get; set; }

        public int SId { get; set; }
        [ForeignKey("SId")]
        public  State State { get; set; }


    }
}
