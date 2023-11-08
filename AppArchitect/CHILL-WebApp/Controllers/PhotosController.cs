using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHILL_WebApp.Data;
using CHILL_WebApp.Models;

namespace CHILL_WebApp.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PhotosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
              /*return _context.Photos != null ? 
                          View(await _context.Photos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Photos'  is null.");*/

            var image = _context.Photos.FirstOrDefault(i => !i.IsLabeled);

            var labels = await _context.Labels.ToListAsync();
            ViewData["Labels"] = labels;
            return View(image);
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path,IsLabeled")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // Sets the image as labeled and loads the next unlabeled image
        [HttpPost]
        public IActionResult LabelImage(int imageId)
        {
            // Label the image by updating the IsLabeled field
            var image = _context.Photos.FirstOrDefault(i => i.Id == imageId);
            if (image != null)
            {
                image.IsLabeled = true;
                _context.SaveChanges();
            }

            // Find the next unlabeled image to load
            var nextUnlabeledImage = _context.Photos.FirstOrDefault(i => !i.IsLabeled);

            return View("Index", nextUnlabeledImage);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,IsLabeled")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.Id))
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
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Photos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Photos'  is null.");
            }
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
          return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        public IActionResult ImageDbUpdateOutdated(int imageId, int labelId, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            // Get the expert (you need to implement authentication)
            Expert expert = _context.Experts.FirstOrDefault(/* Find the expert based on user identity */);

            // Find the photo
            var photo = _context.Photos.FirstOrDefault(i => i.Id == imageId);
            if (photo != null)
            {
                // Update the IsLabeled field
                photo.IsLabeled = true;

                // Create a new Coordinate record
                Coordinate coordinate = new Coordinate
                {
                    X1 = Convert.ToString(x1),
                    Y1 = Convert.ToString(y2),
                    X2 = Convert.ToString(x2),
                    Y2 = Convert.ToString(y2),
                    X3 = Convert.ToString(x3),
                    Y3 = Convert.ToString(y3),
                    X4 = Convert.ToString(x4),
                    Y4 = Convert.ToString(y4),
                    Photos = photo
                };

                // Find the selected label
                Label label = _context.Labels.FirstOrDefault(l => l.Id == labelId);

                if (label != null)
                {
                    // Associate the label and expert with the photo
                    photo.Labels = label; // !!! DB connections are fucked
                    photo.Experts.Add(expert);

                    _context.SaveChanges();
                }
            }

            // Find the next unlabeled image to load
            var nextUnlabeledImage = _context.Photos.FirstOrDefault(i => !i.IsLabeled);

            return View("Index", nextUnlabeledImage);
        }

        // ERROR: FAILS TO CONNECT TO DB

        [HttpPost("/Photos/ImageDbUpdate")]
        public async Task<IActionResult> ImageDbUpdate(int imageId)
        {
            // Get the selected label ID from the form
            int selectedLabelId = Convert.ToInt32(Request.Form["labelId"]);

            // Get the coordinates
            string x1 = Request.Form["x1"];
            string y1 = Request.Form["y1"];
            string x2 = Request.Form["x2"];
            string y2 = Request.Form["y2"];
            string x3 = Request.Form["x3"];
            string y3 = Request.Form["y3"];
            string x4 = Request.Form["x4"];
            string y4 = Request.Form["y4"];

            // Get the expert (you'll need to implement user authentication and retrieve the expert based on the logged-in user) ERROR: USER ID IS SOME STRING OF LETTERS
            /*var user = await _userManager.GetUserAsync(User);
            int userId = Convert.ToInt32(user.Id);
            Expert expert = _context.Experts.FirstOrDefault(e => e.Id == userId);*/

            // Assuming you have a database context named _context
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Create a new Coordinate record
                    Coordinate coordinate = new Coordinate
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        X3 = x3,
                        Y3 = y3,
                        X4 = x4,
                        Y4 = y4,
                        PhotoId = imageId
                    };

                    // Add the coordinate to the database
                    _context.Coordinates.Add(coordinate);
                    _context.SaveChanges();

                    // Get the photo
                    Photo photo = _context.Photos.FirstOrDefault(p => p.Id == imageId);
                    if (photo != null)
                    {
                        // Set IsLabeled to true
                        photo.IsLabeled = true;

                        // Associate the selected label with the photo
                        photo.LabelId = selectedLabelId;

                        // Associate the expert with the photo
                        /*photo.Experts.Add(expert);*/ // Assuming 'Experts' is a collection of experts in the 'Photo' entity

                        // Update the photo in the database
                        _context.Photos.Update(photo);
                        _context.SaveChanges();

                        // Commit the transaction
                        transaction.Commit();
                    }

                    // Handle success
                    return Ok("Labeling completed successfully");
                }
                catch (Exception ex)
                {
                    // Handle any errors, and roll back the transaction if needed
                    transaction.Rollback();
                    return BadRequest("Labeling failed: " + ex.Message);
                }
            }
        }
    }
}
