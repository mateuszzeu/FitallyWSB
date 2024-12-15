using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitally.Data;
using Fitally.Models;

namespace Fitally.Controllers
{
    public class WorkoutDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutDays
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutDays.ToListAsync());
        }

        // GET: WorkoutDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutDay = await _context.WorkoutDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutDay == null)
            {
                return NotFound();
            }

            return View(workoutDay);
        }

        // GET: WorkoutDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,WorkoutDate,DayName,Info")] WorkoutDay workoutDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutDay);
        }

        // GET: WorkoutDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutDay = await _context.WorkoutDays.FindAsync(id);
            if (workoutDay == null)
            {
                return NotFound();
            }
            return View(workoutDay);
        }

        // POST: WorkoutDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,WorkoutDate,DayName,Info")] WorkoutDay workoutDay)
        {
            if (id != workoutDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutDayExists(workoutDay.Id))
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
            return View(workoutDay);
        }

        // GET: WorkoutDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutDay = await _context.WorkoutDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutDay == null)
            {
                return NotFound();
            }

            return View(workoutDay);
        }

        // POST: WorkoutDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutDay = await _context.WorkoutDays.FindAsync(id);
            if (workoutDay != null)
            {
                _context.WorkoutDays.Remove(workoutDay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutDayExists(int id)
        {
            return _context.WorkoutDays.Any(e => e.Id == id);
        }
    }
}
