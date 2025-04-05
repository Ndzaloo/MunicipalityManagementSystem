using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipulity_System.Models;

namespace Municipulity_System.Controllers
{
    public class ServicesRequestedController : Controller
    {
        private readonly DatabaseApplicationDbcontext _context;

        public ServicesRequestedController(DatabaseApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.servicesRequesteds.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicesRequested service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var service = await _context.servicesRequesteds.FindAsync(id);
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServicesRequested service)
        {
            if (ModelState.IsValid)
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.servicesRequesteds.FindAsync(id);
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.servicesRequesteds.FindAsync(id);
            _context.servicesRequesteds.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
