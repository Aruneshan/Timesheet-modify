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
    public class RegisterController : Controller
    {
        private readonly OriginalContext _context;

        public RegisterController(OriginalContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
              return View(await _context.RegisterModel.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.RegisterModel == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,EmployeeId,FirstName,LastName,Dob,Password,ConfirmPassword")] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerModel);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.RegisterModel == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel.FindAsync(id);
            if (registerModel == null)
            {
                return NotFound();
            }
            return View(registerModel);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmailId,EmployeeId,FirstName,LastName,Dob,Password,ConfirmPassword")] RegisterModel registerModel)
        {
            if (id != registerModel.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterModelExists(registerModel.EmployeeId))
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
            return View(registerModel);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.RegisterModel == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.RegisterModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegisterModel'  is null.");
            }
            var registerModel = await _context.RegisterModel.FindAsync(id);
            if (registerModel != null)
            {
                _context.RegisterModel.Remove(registerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterModelExists(string id)
        {
          return _context.RegisterModel.Any(e => e.EmployeeId == id);
        }
    }
}
