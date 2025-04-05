using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipulity_System.Models;

namespace Municipulity_System.Controllers
{
    public class ReportsController : Controller
    {
        private readonly DatabaseApplicationDbcontext _context;

        public ReportsController(DatabaseApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reports.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportID,ReportType,Details,SubmissionDate,Status")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reports);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Reports report)
        {
            if (ModelState.IsValid)
            {
                _context.Update(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            return View(reports);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            _context.Reports.Remove(reports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
