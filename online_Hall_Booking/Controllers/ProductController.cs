using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using online_Hall_Booking.Models;
using online_Hall_Booking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public ProductController(ApplicationDbContext context)
        {
            _context = context;

            
        }
        public IActionResult Index()
        {
            var hallList = _context.Halls.ToList();
            return View(hallList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = _context.Halls
              .FirstOrDefault(m => m.hId == id);
            var facility = _context.FAcilities.FirstOrDefault(f => f.hallId == id);
            var timmimg = _context.timings.FirstOrDefault(f => f.hallId == id);
            var packages= _context.packages.FirstOrDefault(f => f.hallId == id);
            if (hall == null)
            {
                return NotFound();
            }
            TempData["hid"] = hall.hId;
            ProductDetailViewModel vm = new ProductDetailViewModel();

                vm.hallName = hall.Name;
                vm.halldecription = hall.decription;
                vm.Address = hall.Address;
                vm.CoverImageUrl = hall.CoverImageUrl;
                vm.logoFile = hall.logoFile;
                //packages
                if (packages != null)
                    {
                vm.packageName = packages.Name;
                vm.packagedecription = packages.decription;
                vm.personCount = packages.personCount;
                vm.Packacgetype = packages.type;
                vm.charges = packages.charges;
            }

            //facilities
            if (facility != null)
            {
                vm.facilityName = facility.Name;
            }

            //timing
            if (timmimg != null)
            {
                vm.day = timmimg.Name;
                vm.SlotTime = timmimg.dateTime.ToString();
            }
           
          


            return View(vm);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HapId,Name,phone,Email,Remarks,Date,HId")] HallAppointment hallAppointment)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    hallAppointment.HId = (int)TempData["hid"];
                    _context.Add(hallAppointment);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            catch(Exception)
            {
                throw;
            }
          
            return View(hallAppointment);
        }

        public IActionResult Requests()
        {
           
            var reqList = _context.HallAppointment
                .Include(h=>h.Hall)
                .ToList();
            return View(reqList);
        }




    }



}
