using Microsoft.AspNetCore.Mvc;
using Municipulity_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Municipulity_System.Controllers
{
    public class CitizensController : Controller
    {
        private bool CitizensExists(int id)
        { return _context.Citizens.Any(e => e.CitizenID == id); }
        private readonly DatabaseApplicationDbcontext _context;
        public CitizensController(DatabaseApplicationDbcontext context)
        {
            _context = context;
        }
 public async Task<IActionResult> Index()
    {
            var citizens = await _context.Citizens.ToListAsync();
            return View(citizens);
        }

        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName, Address, PhoneNumber, Email, DateOfBirth")] Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                citizen.RegisteredDate = DateTime.Now;
                _context.Add(citizen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitizenID, FullName, Address, PhoneNumber, Email, DateOfBirth")] Citizen citizen)
        {
            if (id != citizen.CitizenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenExists(citizen.CitizenID))
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
            return View(citizen);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = await _context.Citizens
            .FirstOrDefaultAsync(m => m.CitizenID == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }
      [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen ==null) { return NotFound(); }
            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitizenExists(int id)
        {
            return _context.Citizens.Any(e=>e.CitizenID ==id);
        }
    }
}
   
