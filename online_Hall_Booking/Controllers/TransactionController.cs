using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> manager;

        public TransactionController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            manager = userManager;



        }
        public IActionResult Index()
        {
            string login = manager.GetUserId(HttpContext.User);
            var transactionlist = _context.transactions
                .Include(h => h.Hall)
                 .Include(h => h.Order)
                 . Where(s => s.createdBy == login).ToList();
    
            return View(transactionlist);
        }
    }
}
