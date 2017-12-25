using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aprintist.Models;

namespace aprintist.Controllers
{
    public class ObservationsController : Controller
    {
        private readonly ObservationContext _context;

        public ObservationsController(ObservationContext context)
        {
            _context = context;
        }

        // GET: Observations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Observations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observation = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (observation == null)
            {
                return NotFound();
            }

            return View(observation);
        }

        // GET: Observations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Observations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Slicer,Printer,Estimate,Actual")] Observation observation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(observation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(observation);
        }

        // GET: Observations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observation = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (observation == null)
            {
                return NotFound();
            }
            return View(observation);
        }

        // POST: Observations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Slicer,Printer,Estimate,Actual")] Observation observation)
        {
            if (id != observation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(observation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObservationExists(observation.ID))
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
            return View(observation);
        }

        // GET: Observations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observation = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (observation == null)
            {
                return NotFound();
            }

            return View(observation);
        }

        // POST: Observations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var observation = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(observation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObservationExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
