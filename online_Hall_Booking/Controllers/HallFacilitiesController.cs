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
    public class HallFacilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HallFacilitiesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: HallFacilities
        public IActionResult Index()
        {
            //var applicationDbContext = _context.FAcilities.Include(h => h.Hall);
            var login = _userManager.GetUserId(HttpContext.User);

             var hallFacilities = _context.FAcilities
                                   .Include(h=> h.Hall)
                                  .Where(s => s.createdBy == login).ToList();

            /* var hallFacilities = await _context.FAcilities
                 .Include(h => h.Hall)
                 .FirstOrDefaultAsync(m => m.createdBy == login);*/

            return View(hallFacilities);
        }

        // GET: HallFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallFacilities = await _context.FAcilities
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.hfacId == id);
            if (hallFacilities == null)
            {
                return NotFound();
            }

            return View(hallFacilities);
        }

        // GET: HallFacilities/Create
        public IActionResult Create()
        {
            var login = _userManager.GetUserId(HttpContext.User);


            var hallList = _context.Halls       
                                 .Where(s => s.createdBy == login)
                                 .ToList();
            ViewData["hallId"] = new SelectList(hallList, "hId", "Name");
            return View();
        }

        // POST: HallFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hfacId,Name,status,createdAt,createdBy,updatedBy,hallId")] HallFacilities hallFacilities)
        {
            if (ModelState.IsValid)
            {

                hallFacilities.createdBy = _userManager.GetUserId(HttpContext.User);
                hallFacilities.updatedBy = _userManager.GetUserId(HttpContext.User);

                _context.Add(hallFacilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallFacilities.hallId);
            return View(hallFacilities);
        }

        // GET: HallFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallFacilities = await _context.FAcilities.FindAsync(id);
            if (hallFacilities == null)
            {
                return NotFound();
            }
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallFacilities.hallId);
            return View(hallFacilities);
        }

        // POST: HallFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hfacId,Name,type,status,createdAt,createdBy,updatedBy,hallId")] HallFacilities hallFacilities)
        {
            if (id != hallFacilities.hfacId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hallFacilities.createdBy = _userManager.GetUserId(HttpContext.User);
                    hallFacilities.updatedBy = _userManager.GetUserId(HttpContext.User);
                    _context.Update(hallFacilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallFacilitiesExists(hallFacilities.hfacId))
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
            ViewData["hallId"] = new SelectList(_context.Halls, "hId", "Name", hallFacilities.hallId);
            return View(hallFacilities);
        }

        // GET: HallFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallFacilities = await _context.FAcilities
                .Include(h => h.Hall)
                .FirstOrDefaultAsync(m => m.hfacId == id);
            if (hallFacilities == null)
            {
                return NotFound();
            }

            return View(hallFacilities);
        }

        // POST: HallFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hallFacilities = await _context.FAcilities.FindAsync(id);
            _context.FAcilities.Remove(hallFacilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallFacilitiesExists(int id)
        {
            return _context.FAcilities.Any(e => e.hfacId == id);
        }
    }
}
