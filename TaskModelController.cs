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
    public class TaskModelController : Controller
    {
        private readonly OriginalContext _context;

        public TaskModelController(OriginalContext context)
        {
            _context = context;
        }

        // GET: TaskModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskModel.Include(t => t.Workspace);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskModel == null)
            {
                return NotFound();
            }

            var taskModel = await _context.TaskModel
                .Include(t => t.Workspace)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: TaskModel/Create
        public IActionResult Create()
        {
            ViewData["WorkspaceId"] = new SelectList(_context.Set<WorkSpace>(), "WorkspaceId", "WorkspaceId");
            return View();
        }

        // POST: TaskModel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,WorkspaceId")] TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkspaceId"] = new SelectList(_context.Set<WorkSpace>(), "WorkspaceId", "WorkspaceId", taskModel.WorkspaceId);
            return View(taskModel);
        }

        // GET: TaskModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskModel == null)
            {
                return NotFound();
            }

            var taskModel = await _context.TaskModel.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            ViewData["WorkspaceId"] = new SelectList(_context.Set<WorkSpace>(), "WorkspaceId", "WorkspaceId", taskModel.WorkspaceId);
            return View(taskModel);
        }

        // POST: TaskModel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,WorkspaceId")] TaskModel taskModel)
        {
            if (id != taskModel.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskModel.TaskId))
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
            ViewData["WorkspaceId"] = new SelectList(_context.Set<WorkSpace>(), "WorkspaceId", "WorkspaceId", taskModel.WorkspaceId);
            return View(taskModel);
        }

        // GET: TaskModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskModel == null)
            {
                return NotFound();
            }

            var taskModel = await _context.TaskModel
                .Include(t => t.Workspace)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: TaskModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaskModel'  is null.");
            }
            var taskModel = await _context.TaskModel.FindAsync(id);
            if (taskModel != null)
            {
                _context.TaskModel.Remove(taskModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
          return _context.TaskModel.Any(e => e.TaskId == id);
        }
    }
}
