using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tray.Data;
using Tray.Models;

namespace Tray.Controllers
{
    public class TrayModelController : Controller
    {
        private readonly TrayContext _context;

        public TrayModelController(TrayContext context)
        {
            _context = context;
        }

        // GET: TrayModels
        public async Task<IActionResult> Index() => _context.TrayModel != null ?
                          View(await _context.TrayModel.ToListAsync()) :
                          Problem("Entity set 'TrayContext.TrayModel'  is null.");

        // GET: TrayModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrayModel == null)
            {
                return NotFound();
            }

            var trayModel = await _context.TrayModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trayModel == null)
            {
                return NotFound();
            }

            return View(trayModel);
        }

        // GET: TrayModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrayModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelName,Size,Color,Price,Material,Shape,Pattern,Theme")] TrayModel trayModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trayModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trayModel);
        }

        // GET: TrayModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrayModel == null)
            {
                return NotFound();
            }

            var trayModel = await _context.TrayModel.FindAsync(id);
            if (trayModel == null)
            {
                return NotFound();
            }
            return View(trayModel);
        }

        // POST: TrayModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,Size,Color,Price,Material,Shape,Pattern,Theme")] TrayModel trayModel)
        {
            if (id != trayModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trayModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrayModelExists(trayModel.Id))
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
            return View(trayModel);
        }

        // GET: TrayModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrayModel == null)
            {
                return NotFound();
            }

            var trayModel = await _context.TrayModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trayModel == null)
            {
                return NotFound();
            }

            return View(trayModel);
        }

        // POST: TrayModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrayModel == null)
            {
                return Problem("Entity set 'TrayContext.TrayModel'  is null.");
            }
            var trayModel = await _context.TrayModel.FindAsync(id);
            if (trayModel != null)
            {
                _context.TrayModel.Remove(trayModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrayModelExists(int id)
        {
          return (_context.TrayModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
