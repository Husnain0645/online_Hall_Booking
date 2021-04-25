using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class State
    {
        [Key]
        public int sId { get; set; }
        [Required]
        public string Name { get; set; }
        public short status { get; set; }

        public int CId { get; set; }
        [ForeignKey("CId")]
        public City City { get; set; }


    }
}
