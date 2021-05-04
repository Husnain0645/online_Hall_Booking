using online_Hall_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.ViewModel
{
    public class ProductDetailViewModel
    {
        //hall
        public string hallName { get; set; }
        public string halldecription { get; set; }

        public string Address { get; set; }
        public string CoverImageUrl { get; set; }
        public string logoFile { get; set; }
        public List<Hall> halllist { get; set; }




        //packages
        public List<HallPackages> perheadList { get; set; }
        public List<HallPackages> Lumsumlist { get; set; }
     

        //facilities

        public string facilityName { get; set; }
        //timing
        public string day { get; set; }
        public string SlotTime { get; set; }





    }
}
