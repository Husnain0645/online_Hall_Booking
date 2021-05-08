using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using online_Hall_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this._userManager = userManager;


        }


        public IActionResult Index()
        {
            var login = _userManager.GetUserId(HttpContext.User);
            var orderlist = _context.Orders
                .Include(h => h.Hall)
                 .Include(h => h.Package)
                 .Where(s => s.createdBy == login).ToList();
                
            
            return View(orderlist);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Orders = await _context.Orders.FindAsync(id);
            if (Orders == null)
            {
                return NotFound();
            }
            TempData["ordpkgId"] = Orders.PId;
            TempData["ordHallId"] = Orders.hallId;



            return View(Orders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, hallOrder Orders)
        {
            if (id != Orders.ordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentpackage = _context.packages.FirstOrDefault(h => h.pId == (int)TempData["ordpkgId"]);
                    Orders.hallId =(int) TempData["ordHallId"];
                     Orders.PId = (int)TempData["ordpkgId"];
                    Orders.totalAmount = Orders.personCount*currentpackage.charges;
                    Orders.remainingAmount = (Orders.totalAmount - Orders.receivedAmount) - Orders.Discount;
                    Orders.createdBy = _userManager.GetUserId(HttpContext.User);
                    Orders.updatedBy = _userManager.GetUserId(HttpContext.User);



                    _context.Update(Orders);
                    await _context.SaveChangesAsync();


                    HallTransaction transaction = new HallTransaction();
                    if (Orders.receivedAmount != 0)
                    {
                        transaction.refId = currentpackage.pId;
                        transaction.hallId = Orders.hallId;
                        transaction.OrdId = Orders.ordId;
                        transaction.decription = "Advanced Amount Received";
                        transaction.type = "Sales";
                        transaction.createdBy = _userManager.GetUserId(HttpContext.User);
                        transaction.updatedBy = _userManager.GetUserId(HttpContext.User);
                        transaction.Amount = Orders.receivedAmount;
                        transaction.createdAt = DateTime.Now;
                        _context.transactions.Add(transaction);
                        await _context.SaveChangesAsync();
                    }





                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }

            return View(Orders);
        }




       
    }
}
