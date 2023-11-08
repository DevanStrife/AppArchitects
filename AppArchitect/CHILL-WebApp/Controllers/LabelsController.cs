using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHILL_WebApp.Data;
using CHILL_WebApp.Models;

namespace CHILL_WebApp.Controllers
{
    public class LabelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
              return _context.Labels != null ? 
                          View(await _context.Labels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Labels'  is null.");
        }

        // GET: Labels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Labels == null)
            {
                return NotFound();
            }

            var label = await _context.Labels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // GET: Labels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Colour")] Label label)
        {
            if (ModelState.IsValid)
            {
                _context.Add(label);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Labels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Labels == null)
            {
                return NotFound();
            }

            var label = await _context.Labels.FindAsync(id);
            if (label == null)
            {
                return NotFound();
            }
            return View(label);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Colour")] Label label)
        {
            if (id != label.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(label);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelExists(label.Id))
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
            return View(label);
        }

        // GET: Labels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Labels == null)
            {
                return NotFound();
            }

            var label = await _context.Labels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Labels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Labels'  is null.");
            }
            var label = await _context.Labels.FindAsync(id);
            if (label != null)
            {
                _context.Labels.Remove(label);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelExists(int id)
        {
          return (_context.Labels?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /*[HttpPost]
        public async Task<IActionResult> UpdateLabels(IEnumerable<Label> labels)
        {
            if (ModelState.IsValid)
            {
                // Update the labels in the database
                foreach (var label in labels)
                {
                    _context.Entry(label).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();

                // Return a success response as JSON
                return Json(new { success = true });
            }

            // Return a failure response as JSON, optionally with error messages
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }*/
    }
}
