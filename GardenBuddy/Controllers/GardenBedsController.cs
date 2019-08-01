using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenBuddy.Data;
using GardenBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GardenBuddy.Controllers
{
    public class GardenBedsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GardenBedsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        // This method will be called every time we need to get the current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: GardenBeds
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var userGarden = _context.GardenBeds.Where(g => currentUser.Id == g.userId);
            return View(await userGarden.ToListAsync());
        }

        // GET: GardenBeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gardenBed = await _context.GardenBeds
                .FirstOrDefaultAsync(m => m.GardenBedId == id);
            if (gardenBed == null)
            {
                return NotFound();
            }

            return View(gardenBed);
        }

        // GET: GardenBeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GardenBeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GardenBed gardenBed)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {

                var currUser = await GetCurrentUserAsync();
                gardenBed.userId = currUser.Id;
                _context.Add(gardenBed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gardenBed);
        }

        // GET: GardenBeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gardenBed = await _context.GardenBeds.FindAsync(id);
            if (gardenBed == null)
            {
                return NotFound();
            }
            return View(gardenBed);
        }

        // POST: GardenBeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GardenBedId,name")] GardenBed gardenBed)
        {
            if (id != gardenBed.GardenBedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gardenBed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenBedExists(gardenBed.GardenBedId))
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
            return View(gardenBed);
        }

        // GET: GardenBeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gardenBed = await _context.GardenBeds
                .FirstOrDefaultAsync(m => m.GardenBedId == id);
            if (gardenBed == null)
            {
                return NotFound();
            }

            return View(gardenBed);
        }

        // POST: GardenBeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gardenBed = await _context.GardenBeds.FindAsync(id);
            _context.GardenBeds.Remove(gardenBed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenBedExists(int id)
        {
            return _context.GardenBeds.Any(e => e.GardenBedId == id);
        }
    }
}
