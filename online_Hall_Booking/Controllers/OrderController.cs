using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_Hall_Booking.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;


        }
        public IActionResult Index()
        {
            var orderlist = _context.Orders
                .Include(h => h.Hall)
                 .Include(h => h.Package)
                .ToList();
            return View(orderlist);
        }
    }
}
