using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Original.Data;
using Original.Models;

namespace Original.Controllers
{
    public class ManagersController : Controller
    {
        private readonly OriginalContext _context;

        public ManagersController(OriginalContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Managers.Include(m => m.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.ManagerId == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Set<ApplicationUser>(), "ProjectManagerId", "ProjectManagerId");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,ManagerId")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Set<ApplicationUser>(), "ProjectManagerId", "ProjectManagerId", managers.EmployeeId);
            return View(managers);
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers.FindAsync(id);
            if (managers == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Set<ApplicationUser>(), "ProjectManagerId", "ProjectManagerId", managers.EmployeeId);
            return View(managers);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,ManagerId")] Managers managers)
        {
            if (id != managers.ManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagersExists(managers.ManagerId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Set<ApplicationUser>(), "ProjectManagerId", "ProjectManagerId", managers.EmployeeId);
            return View(managers);
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.ManagerId == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Managers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Managers'  is null.");
            }
            var managers = await _context.Managers.FindAsync(id);
            if (managers != null)
            {
                _context.Managers.Remove(managers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagersExists(string id)
        {
            return _context.Managers.Any(e => e.ManagerId == id);
        }
    }
}
