using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.AssignmentFinal.Data;
using COMP003B.AssignmentFinal.Models;

namespace COMP003B.AssignmentFinal.Controllers
{
    public class BuildProfilesController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public BuildProfilesController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: BuildProfiles
        public async Task<IActionResult> Index()
        {
              return _context.BuildProfiles != null ? 
                          View(await _context.BuildProfiles.ToListAsync()) :
                          Problem("Entity set 'WebDevAcademyContext.BuildProfiles'  is null.");
        }

        // GET: BuildProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuildProfiles == null)
            {
                return NotFound();
            }

            var buildProfile = await _context.BuildProfiles
                .FirstOrDefaultAsync(m => m.BuildProfileId == id);
            if (buildProfile == null)
            {
                return NotFound();
            }

            return View(buildProfile);
        }

        // GET: BuildProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildProfileId,ProfileGender,ProfileHeight,ProfileWeight")] BuildProfile buildProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildProfile);
        }

        // GET: BuildProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuildProfiles == null)
            {
                return NotFound();
            }

            var buildProfile = await _context.BuildProfiles.FindAsync(id);
            if (buildProfile == null)
            {
                return NotFound();
            }
            return View(buildProfile);
        }

        // POST: BuildProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildProfileId,ProfileGender,ProfileHeight,ProfileWeight")] BuildProfile buildProfile)
        {
            if (id != buildProfile.BuildProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildProfileExists(buildProfile.BuildProfileId))
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
            return View(buildProfile);
        }

        // GET: BuildProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuildProfiles == null)
            {
                return NotFound();
            }

            var buildProfile = await _context.BuildProfiles
                .FirstOrDefaultAsync(m => m.BuildProfileId == id);
            if (buildProfile == null)
            {
                return NotFound();
            }

            return View(buildProfile);
        }

        // POST: BuildProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuildProfiles == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.BuildProfiles'  is null.");
            }
            var buildProfile = await _context.BuildProfiles.FindAsync(id);
            if (buildProfile != null)
            {
                _context.BuildProfiles.Remove(buildProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildProfileExists(int id)
        {
          return (_context.BuildProfiles?.Any(e => e.BuildProfileId == id)).GetValueOrDefault();
        }
    }
}
