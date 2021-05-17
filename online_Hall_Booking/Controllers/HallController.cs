using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using online_Hall_Booking.Data;
using online_Hall_Booking.Models;

namespace online_Hall_Booking.Controllers
{
    public class HallController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment hostingEnvironment;
       

        public HallController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnvironment )
        {
            _context = context;
            this._userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Halls
        public IActionResult Index()
        {
             var login = _userManager.GetUserId(HttpContext.User);

            var hall = _context.Halls
                                  .Include(h => h.City)
                                 .Where(s => s.createdBy == login).ToList();
            return View( hall);
        }

        // GET: Halls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.hId == id);
            if (hall == null)
            {
                return NotFound();
            }

            return View(hall);
        }

        // GET: Halls/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.cities, "cId", "Name");
            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string city, string state, string country,[Bind("hId,Name,decription,Address,createdAt,createdBy,updatedBy,CoverImageUrl,coverIphoto,Logo,logoFile,status,CId")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                

                //cover

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "hall/cover/");
                  
                   string uniqueFileName = Guid.NewGuid().ToString() + "_" + hall.coverIphoto.FileName;
                  string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    hall.coverIphoto.CopyTo(new FileStream(filePath, FileMode.Create));
                hall.CoverImageUrl = uniqueFileName;
                //logo
                string uploadsFolder2 = Path.Combine(hostingEnvironment.WebRootPath, "hall/Logo/");

                string uniqueFileName2 = Guid.NewGuid().ToString() + "_" + hall.Logo.FileName;
                string filePath2 = Path.Combine(uploadsFolder2, uniqueFileName2);

                hall.Logo.CopyTo(new FileStream(filePath2, FileMode.Create));
                hall.logoFile = uniqueFileName2;
                hall.createdBy = _userManager.GetUserId(HttpContext.User);
                hall.updatedBy = _userManager.GetUserId(HttpContext.User);

                var cityname = _context.cities.Where(c => c.Name == city)
                                              .FirstOrDefault();
                if (cityname!=null)
                {
                    hall.CId = cityname.cId;

                }

                else
                {
                    City newcity = new City();
                    newcity.Name = city;
                    _context.cities.Add(newcity);
                    await _context.SaveChangesAsync();
                    hall.CId = newcity.cId;

                    State s = new State();
                    s.Name = state;
                    s.CId= newcity.cId;
                    _context.states.Add(s);
                    await _context.SaveChangesAsync();

                    Country co = new Country();
                    co.Name = country;
                    co.SId = s.sId;
                    _context.countries.Add(co);
                    await _context.SaveChangesAsync();

                }
                _context.Add(hall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(hall);
        }

        // GET: Halls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls.FindAsync(id);
            TempData["cover"] = hall.CoverImageUrl;
            TempData["logo"] = hall.logoFile;
            if (hall == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.cities, "cId", "Name", hall.CId);
            return View(hall);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile file1, IFormFile file2, [Bind("hId,Name,decription,Address,createdAt,createdBy,updatedBy,CoverImageUrl,logoFile,status,CId")] Hall hall)
        {
            if (id != hall.hId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file1 != null && file2 !=null)
                    {

                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "hall/cover/");

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file1.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        file1.CopyTo(new FileStream(filePath, FileMode.Create));
                        hall.CoverImageUrl = uniqueFileName;
                        if (System.IO.File.Exists(TempData["cover"].ToString()))
                        {
                            System.IO.File.Delete(TempData["cover"].ToString());
                        }

                        //logo
                        string uploadsFolder2 = Path.Combine(hostingEnvironment.WebRootPath, "hall/Logo/");

                        string uniqueFileName2 = Guid.NewGuid().ToString() + "_" + file2.FileName;
                        string filePath2 = Path.Combine(uploadsFolder2, uniqueFileName2);

                        file2.CopyTo(new FileStream(filePath2, FileMode.Create));
                        
                        hall.logoFile = uniqueFileName2;

                       

                        if (System.IO.File.Exists(TempData["logo"].ToString()))
                        {
                            System.IO.File.Delete(TempData["logo"].ToString());
                        }
                        hall.createdBy = _userManager.GetUserId(HttpContext.User);
                        hall.updatedBy = _userManager.GetUserId(HttpContext.User);
                        _context.Update(hall);
                        await _context.SaveChangesAsync();

                    }

                    else
                    {
                        hall.createdBy = _userManager.GetUserId(HttpContext.User);
                        hall.updatedBy = _userManager.GetUserId(HttpContext.User);
                        hall.CoverImageUrl = TempData["cover"].ToString();
                        hall.logoFile = TempData["logo"].ToString();
                        _context.Update(hall);
                        await _context.SaveChangesAsync();
                    }
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallExists(hall.hId))
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
            ViewData["CId"] = new SelectList(_context.cities, "cId", "Name", hall.CId);
            return View(hall);
        }

        // GET: Halls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .Include(h => h.City)
                .FirstOrDefaultAsync(m => m.hId == id);
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
            var hall = await _context.Halls.FindAsync(id);
            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallExists(int id)
        {
            return _context.Halls.Any(e => e.hId == id);
        }
    }
}
