using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class Hall
    {

        [Key]
        public int hId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string decription { get; set; }

        [Required]
        public string Address  { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        [NotMapped]
        
        public IFormFile coverIphoto { get; set; }
        public string CoverImageUrl { get; set; }
        [NotMapped]
        
        public IFormFile Logo { get; set; }
        public string logoFile { get; set; }
        public short status { get; set; }


        public int CId { get; set; }
        [ForeignKey("CId")]
        public City City { get; set; }



    }
}
