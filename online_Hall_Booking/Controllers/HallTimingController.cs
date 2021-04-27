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
    public class HallTimingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HallTimingController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: HallTiming
        public IActionResult Index()
        {
            var login = _userManager.GetUserId(HttpContext.User);

            var timingList = _context.timings
                                .Include(h=>h.Hall)
                                 .Where(s => s.createdBy == login)
                                 .ToList();
            return View(timingList);
        }

        // GET: HallTiming/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallTiming = await _context.timings
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.htId == id);
            if (hallTiming == null)
            {
                return NotFound();
            }

            return View(hallTiming);
        }

        // GET: HallTiming/Create
        public IActionResult Create()
        {
            var login = _userManager.GetUserId(HttpContext.User);


            var hallList = _context.Halls
                                 .Where(s => s.createdBy == login)
                                 .ToList();
            ViewData["hallId"] = new SelectList(hallList, "hId", "Name");
            return View();
        }

        // POST: HallTiming/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("htId,Name,dateTime,createdBy,updatedBy,status,hallId")] HallTiming hallTiming)
        {
            if (ModelState.IsValid)
            {
                hallTiming.createdBy = _userManager.GetUserId(HttpContext.User);
                hallTiming.updatedBy = _userManager.GetUserId(HttpContext.User);
                _context.Add(hallTiming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallTiming.hallId);
            return View(hallTiming);
        }

        // GET: HallTiming/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallTiming = await _context.timings.FindAsync(id);
            if (hallTiming == null)
            {
                return NotFound();
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Address", hallTiming.hallId);
            return View(hallTiming);
        }

        // POST: HallTiming/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("htId,Name,dateTime,createdBy,updatedBy,status,hallId")] HallTiming hallTiming)
        {
            if (id != hallTiming.htId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hallTiming);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallTimingExists(hallTiming.htId))
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
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Address", hallTiming.hallId);
            return View(hallTiming);
        }

        // GET: HallTiming/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallTiming = await _context.timings
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.htId == id);
            if (hallTiming == null)
            {
                return NotFound();
            }

            return View(hallTiming);
        }

        // POST: HallTiming/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hallTiming = await _context.timings.FindAsync(id);
            _context.timings.Remove(hallTiming);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallTimingExists(int id)
        {
            return _context.timings.Any(e => e.htId == id);
        }
    }
}
