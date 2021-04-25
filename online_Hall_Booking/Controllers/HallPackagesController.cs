using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using online_Hall_Booking.Models;

namespace online_Hall_Booking.Controllers
{
    public class HallPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HallPackagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: HallPackages
        public IActionResult Index()
        {
            var login = _userManager.GetUserId(HttpContext.User);

            var packagesList = _context.packages
                                .Include(h=>h.Hall)
                                 .Where(s => s.createdBy == login)
                                 .ToList();
            return View(packagesList);
        }

        // GET: HallPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallPackages = await _context.packages
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.pId == id);
            if (hallPackages == null)
            {
                return NotFound();
            }

            return View(hallPackages);
        }

        // GET: HallPackages/Create
        public IActionResult Create()
        {
            var login = _userManager.GetUserId(HttpContext.User);
          

            var hallList = _context.Halls
                                 .Where(s => s.createdBy == login)
                                 .ToList();
            ViewData["hallId"] = new SelectList(hallList, "hId", "Name");
            return View();
        }

        // POST: HallPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pId,Name,decription,createdAt,createdBy,updatedBy,personCount,charges,type,status,hallId")] HallPackages hallPackages)
        {
            if (ModelState.IsValid)
            {
                hallPackages.createdBy = _userManager.GetUserId(HttpContext.User);
                hallPackages.updatedBy = _userManager.GetUserId(HttpContext.User);
                _context.Add(hallPackages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallPackages.hallId);
            return View(hallPackages);
        }

        // GET: HallPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallPackages = await _context.packages.FindAsync(id);
            if (hallPackages == null)
            {
                return NotFound();
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallPackages.hallId);
            return View(hallPackages);
        }

        // POST: HallPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pId,Name,decription,createdAt,createdBy,updatedBy,personCount,charges,type,status,hallId")] HallPackages hallPackages)
        {
            if (id != hallPackages.pId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hallPackages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallPackagesExists(hallPackages.pId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallPackages.hallId);
            return View(hallPackages);
        }

        // GET: HallPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallPackages = await _context.packages
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.pId == id);
            if (hallPackages == null)
            {
                return NotFound();
            }

            return View(hallPackages);
        }

        // POST: HallPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hallPackages = await _context.packages.FindAsync(id);
            _context.packages.Remove(hallPackages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallPackagesExists(int id)
        {
            return _context.packages.Any(e => e.pId == id);
        }
    }
}
