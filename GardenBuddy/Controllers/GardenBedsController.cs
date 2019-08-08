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
using GardenBuddy.Models.GardenBedViewModels;
using Microsoft.AspNetCore.Authorization;
using static GardenBuddy.Models.GardenBedViewModels.GardenBedDetailsViewModel;

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
        [Authorize]
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
                .Include(u => u.user)
                .Include(pg => pg.PlantGardens)
                .ThenInclude(p => p.Plant)
                .FirstOrDefaultAsync(m => m.GardenBedId == id);
            if (gardenBed == null)
            {
                return NotFound();
            }

            GardenBedDetailsViewModel viewmodel = new GardenBedDetailsViewModel
            {
                GardenBeds = gardenBed
                
            };

            viewmodel.totalWidth = gardenBed.PlantGardens
                .GroupBy(rw => rw.Plant)
                .Select(p => new totalRowWidth
                {
                    Plant = p.Key,
                    rowWidth = p.Key.rowWidth * p.Select(l => l.PlantId).Count()
                }).ToList();

            return View(viewmodel);
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
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            var currUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)


            {
                try
                {
                    gardenBed.userId = currUser.Id;
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

        public async Task<IActionResult> AddPlant()
        {
            var currUser = await GetCurrentUserAsync();


            AddPlantViewModel viewmodel = new AddPlantViewModel
            {
                GardenList = await _context.GardenBeds.Where(u => u.userId == currUser.Id).Select(g => new SelectListItem
                {
                    Text = g.name,
                    Value = g.GardenBedId.ToString()
                }).ToListAsync(),

                PlantList = await _context.Plants.Select(p => new SelectListItem(p.PlantName, p.PlantId.ToString())).ToListAsync()
        };

            return View(viewmodel);
        }

        // POST: GardenBeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlant(AddPlantViewModel viewmodel)
        {
            viewmodel.PlantGarden = new PlantGarden
            {
                Plant = await _context.Plants.FindAsync(viewmodel.PlantId),
                GardenBed = await _context.GardenBeds.FindAsync(viewmodel.GardenBedId),
                rowNumber = viewmodel.PlantGarden.rowNumber,
                plantCount = viewmodel.PlantGarden.plantCount
                
            };

            if (ModelState.IsValid)
            {

                _context.Add(viewmodel.PlantGarden);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "GardenBeds", new { id = viewmodel.GardenBedId });
            }
            return NotFound();
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> PlantDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        public async Task<IActionResult> EditPlant(int? id)
        {
            var currUser = await GetCurrentUserAsync();


            EditGardenPlantViewModel viewmodel = new EditGardenPlantViewModel
            {
                PlantList = await _context.Plants.Select(p => new SelectListItem(p.PlantName, p.PlantId.ToString())).ToListAsync(),
                PlantGarden = await _context.PlantGardens.FindAsync(id)

            };

            return View(viewmodel);
        }

        // POST: GardenBeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlant(EditGardenPlantViewModel viewmodel)
        {

            var PlantGarden = viewmodel.PlantGarden;
            var GardenBed = await _context.GardenBeds.FindAsync(viewmodel.GardenBedId);
            var Plant = await _context.Plants.FindAsync(viewmodel.PlantGarden.PlantId);
            PlantGarden.GardenBed = GardenBed;
            PlantGarden.Plant = Plant;

            ModelState.Remove("PlantGarden.PlantList");
            ModelState.Remove("PlantGarden.Plants");



            //viewmodel.PlantGarden = new PlantGarden
            //{
            //    Plant = await _context.Plants.FindAsync(viewmodel.PlantId),
            //    rowNumber = viewmodel.PlantGarden.rowNumber,
            //    plantCount = viewmodel.PlantGarden.plantCount,
            //    GardenBedId = viewmodel.GardenBedId,
            //    PlantId = viewmodel.PlantId,
            //    PlantGardenId = viewmodel.PlantGarden.PlantGardenId
            //};

            if (ModelState.IsValid)
            {

                _context.Update(PlantGarden);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "GardenBeds", new {id=viewmodel.GardenBedId});
            }
            return NotFound();
        }

        private bool GardenBedExists(int id)
        {
            return _context.GardenBeds.Any(e => e.GardenBedId == id);
        }
    }
}
