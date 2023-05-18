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
    public class TrainersController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public TrainersController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
              return _context.Trainers != null ? 
                          View(await _context.Trainers.ToListAsync()) :
                          Problem("Entity set 'WebDevAcademyContext.Trainers'  is null.");
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }

			ViewBag.Specialties = from s in _context.Trainers
							  join e in _context.TrainerSpecialties on s.TrainerId equals e.TrainerId
							  join c in _context.Specialties on e.SpecialtyId equals c.SpecialtyId
							  where s.TrainerId == id
							  select c;

			return View(trainer);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,TrainerName,TrainerGender,Age")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainerId,TrainerName,TrainerGender,Age")] Trainer trainer)
        {
            if (id != trainer.TrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.TrainerId))
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
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainers == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.Trainers'  is null.");
            }
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
          return (_context.Trainers?.Any(e => e.TrainerId == id)).GetValueOrDefault();
        }
    }
}
