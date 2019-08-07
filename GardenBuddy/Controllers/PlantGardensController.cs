using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenBuddy.Data;
using GardenBuddy.Models;

namespace GardenBuddy.Controllers
{
    public class PlantGardensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantGardensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlantGardens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlantGardens.Include(p => p.GardenBed).Include(p => p.Plant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlantGardens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantGarden = await _context.PlantGardens
                .Include(p => p.GardenBed)
                .Include(p => p.Plant)
                .FirstOrDefaultAsync(m => m.PlantGardenId == id);
            if (plantGarden == null)
            {
                return NotFound();
            }

            return View(plantGarden);
        }

        // GET: PlantGardens/Create
        public IActionResult Create()
        {
            ViewData["GardenBedId"] = new SelectList(_context.GardenBeds, "GardenBedId", "name");
            ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "Disease");
            return View();
        }

        // POST: PlantGardens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantGardenId,PlantId,GardenBedId,rowNumber,plantCount")] PlantGarden plantGarden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantGarden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GardenBedId"] = new SelectList(_context.GardenBeds, "GardenBedId", "name", plantGarden.GardenBedId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "Disease", plantGarden.PlantId);
            return View(plantGarden);
        }

        // GET: PlantGardens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantGarden = await _context.PlantGardens.FindAsync(id);
            if (plantGarden == null)
            {
                return NotFound();
            }
            ViewData["GardenBedId"] = new SelectList(_context.GardenBeds, "GardenBedId", "name", plantGarden.GardenBedId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "Disease", plantGarden.PlantId);
            return View(plantGarden);
        }

        // POST: PlantGardens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantGardenId,PlantId,GardenBedId,rowNumber,plantCount")] PlantGarden plantGarden)
        {
            if (id != plantGarden.PlantGardenId)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantGarden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantGardenExists(plantGarden.PlantGardenId))
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
            ViewData["GardenBedId"] = new SelectList(_context.GardenBeds, "GardenBedId", "name", plantGarden.GardenBedId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "Disease", plantGarden.PlantId);
            return View(plantGarden);
        }

        // GET: PlantGardens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantGarden = await _context.PlantGardens
                .Include(p => p.GardenBed)
                .Include(p => p.Plant)
                .FirstOrDefaultAsync(m => m.PlantGardenId == id);
            if (plantGarden == null)
            {
                return NotFound();
            }

            return View(plantGarden);
        }

        // POST: PlantGardens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantGarden = await _context.PlantGardens.FindAsync(id);
            _context.PlantGardens.Remove(plantGarden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantGardenExists(int id)
        {
            return _context.PlantGardens.Any(e => e.PlantGardenId == id);
        }
    }
}
