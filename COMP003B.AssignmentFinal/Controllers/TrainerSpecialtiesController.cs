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
    public class TrainerSpecialtiesController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public TrainerSpecialtiesController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: TrainerSpecialties
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.TrainerSpecialties.Include(t => t.Specialty).Include(t => t.Trainer);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: TrainerSpecialties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainerSpecialties == null)
            {
                return NotFound();
            }

            var trainerSpecialty = await _context.TrainerSpecialties
                .Include(t => t.Specialty)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainerSpecialty == null)
            {
                return NotFound();
            }

            return View(trainerSpecialty);
        }

        // GET: TrainerSpecialties/Create
        public IActionResult Create()
        {
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "SpecialtyName");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName");
            return View();
        }

        // POST: TrainerSpecialties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainerId,SpecialtyId")] TrainerSpecialty trainerSpecialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainerSpecialty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "SpecialtyName", trainerSpecialty.SpecialtyId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", trainerSpecialty.TrainerId);
            return View(trainerSpecialty);
        }

        // GET: TrainerSpecialties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainerSpecialties == null)
            {
                return NotFound();
            }

            var trainerSpecialty = await _context.TrainerSpecialties.FindAsync(id);
            if (trainerSpecialty == null)
            {
                return NotFound();
            }
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "SpecialtyName", trainerSpecialty.SpecialtyId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", trainerSpecialty.TrainerId);
            return View(trainerSpecialty);
        }

        // POST: TrainerSpecialties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainerId,SpecialtyId")] TrainerSpecialty trainerSpecialty)
        {
            if (id != trainerSpecialty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainerSpecialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerSpecialtyExists(trainerSpecialty.Id))
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
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "SpecialtyId", "SpecialtyName", trainerSpecialty.SpecialtyId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", trainerSpecialty.TrainerId);
            return View(trainerSpecialty);
        }

        // GET: TrainerSpecialties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainerSpecialties == null)
            {
                return NotFound();
            }

            var trainerSpecialty = await _context.TrainerSpecialties
                .Include(t => t.Specialty)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainerSpecialty == null)
            {
                return NotFound();
            }

            return View(trainerSpecialty);
        }

        // POST: TrainerSpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainerSpecialties == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.TrainerSpecialties'  is null.");
            }
            var trainerSpecialty = await _context.TrainerSpecialties.FindAsync(id);
            if (trainerSpecialty != null)
            {
                _context.TrainerSpecialties.Remove(trainerSpecialty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerSpecialtyExists(int id)
        {
          return (_context.TrainerSpecialties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
