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
            var perheadpackages= _context.packages.Where(h=> h.hallId==id && h.type=="perhead").ToList();
            var lumsumpackages = _context.packages.Where(h => h.hallId == id && h.type == "lumsum").ToList();
            if (hall == null)
            {
                return NotFound();
            }
            TempData["hid"] = hall.hId;
            var listofhalls = _context.Halls
                    .Where(h => h.CId == hall.CId).Take(4).ToList();
            ProductDetailViewModel vm = new ProductDetailViewModel();
                 
                vm.hallName = hall.Name;
                vm.halldecription = hall.decription;
                vm.Address = hall.Address;
                vm.CoverImageUrl = hall.CoverImageUrl;
                vm.logoFile = hall.logoFile;
            vm.halllist = listofhalls;
            //packages
            vm.perheadList = perheadpackages;
            vm.Lumsumlist = lumsumpackages;

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

        public IActionResult Create(int? id)
        {
            var pakage = _context.packages.FirstOrDefault(p => p.pId == id);
            if(pakage.type=="perhead")
            {

                    var perheadId= pakage.pId;
                TempData["pkgId"] = perheadId;


            }

            if (pakage.type == "lumsum")
            {
                var lumSumId = pakage.pId;
                TempData["pkgId"] = lumSumId;

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string status, [Bind("HapId,Name,phone,Email,Remarks,Date,HId")] HallAppointment hallAppointment)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    hallAppointment.HId = (int)TempData["hid"];
                    hallAppointment.PId = (int)TempData["pkgId"];
                    if(status == "Complete")
                    {
                        hallAppointment.Status = 1;
                    }
                    else if (status == "Pending")
                    {
                        hallAppointment.Status = 0;
                    }
                    else if (status == "Decline")
                    {
                        hallAppointment.Status = 0;
                    }

                    var dateTime = DateTime.Now;
                    hallAppointment.Date = dateTime.ToShortDateString();
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



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallAppointment = await _context.HallAppointment.FindAsync(id);
            if (hallAppointment == null)
            {
                return NotFound();
            }
            TempData["appPkgId"] = hallAppointment.PId;
            TempData["appHallId"] = hallAppointment.HId;


            return View(hallAppointment);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  HallAppointment hallAppointment)
        {
            if (id != hallAppointment.HapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                

                try
                {
                    hallAppointment.HId =(int) TempData["appHallId"];
                    hallAppointment.PId = (int)TempData["appPkgId"];
                    _context.Update(hallAppointment);
                    await _context.SaveChangesAsync();

                    var currentpackage = _context.packages.FirstOrDefault(h => h.pId == (int)TempData["appPkgId"]);


                    hallOrder order = new hallOrder();
                    if (hallAppointment.Status == 1)
                    {
                        order.hallId = currentpackage.hallId;
                        order.PId = currentpackage.pId;
                        order.personCount = currentpackage.personCount;
                        order.totalAmount = currentpackage.charges;
                        order.receivedAmount = 0.00;
                        order.type = currentpackage.type;
                        var dateTime = DateTime.Now;
                        order.createdAt = dateTime.ToShortDateString();
                        _context.Orders.Add(order);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                    
                }
                return RedirectToAction(nameof(Requests));
            }
            
            return View(hallAppointment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.HallAppointment
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.HapId == id);
            if (hall == null)
            {
                return NotFound();
            }

            return View(hall);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hallAppointments = await _context.HallAppointment.FindAsync(id);
            _context.HallAppointment.Remove(hallAppointments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Requests));
        }





        public IActionResult Requests()
        {
           
            var reqList = _context.HallAppointment
                .Include(h=>h.Hall )
                 .Include(h => h.Package)
                .ToList();
            return View(reqList);
        }

        public IActionResult RelatedProducts()
        {
            var hall = _context.Halls
               .FirstOrDefault(m => m.hId == (int)TempData["hid"]);
            if (hall != null)
            {
                var reqlist = _context.Halls
                    .Where(h => h.CId==hall.CId).Take(4).ToList();
                return View(reqlist);
            }
            return View();
        }




    }



}
