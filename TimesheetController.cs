#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Original.Data;
using Microsoft.EntityFrameworkCore;
using Original.Models;

public class TimesheetController : Controller
{
    private readonly OriginalContext _context;

    public TimesheetController(OriginalContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var entries = _context.Timesheet.ToList();
        return View(entries);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Timesheet entry)
    {
        if (ModelState.IsValid)
        {
            _context.Timesheet.Add(entry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(entry);
    }

    public ActionResult Edit(int id)
    {
        var entry = _context.Timesheet.Find(id);
        if (entry == null)
        {
            return HttpNotFound();
        }

        return View(entry);
    }

    private ActionResult HttpNotFound()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult Edit(Timesheet entry)
    {
        if (entry is null)
        {
            throw new ArgumentNullException(nameof(entry));
        }

        if (ModelState.IsValid)
        {
            _context.Entry(entry).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(entry);
    }

    public ActionResult Delete(int id)
    {
        var entry = _context.Timesheet.Find(id);
        if (entry == null)
        {
            return HttpNotFound();
        }

        return View(entry);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var entry = _context.Timesheet.Find(id);
        _context.Timesheet.Remove(entry);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
