using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipulity_System.Models;

namespace Municipulity_System.Controllers
{
    public class StaffController : Controller
    {
        private readonly DatabaseApplicationDbcontext _context;

        public StaffController(DatabaseApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Staff.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Update(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

