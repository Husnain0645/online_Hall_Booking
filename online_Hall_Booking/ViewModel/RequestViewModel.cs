using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.ViewModel
{
    public class RequestViewModel
    {



        //hallApppointment
        public string Name { get; set; }
       
        public string phone { get; set; }
       
        public string Email { get; set; }

        public string Remarks { get; set; }

        public string AdminRemarks { get; set; }

        public String Date { get; set; }

        public sbyte Status { get; set; }

        public double Persons { get; set; }
        public double AdvancedAmount { get; set; }
        public double RemaingAmount { get; set; }
        public double TotalAmount { get; set; }




    }
}
