using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;
using NuGet.Packaging.Signing;

namespace GenshinTierList.Controllers
{
    public class TierListsController : Controller
    {
        private readonly GenshinTierListContext _context;

        public TierListsController(GenshinTierListContext context)
        {
            _context = context;
        }

        // GET: TierLists
        /*public async Task<IActionResult> Index()
        {
              return View(await _context.TierList.ToListAsync());
        }*/
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.TierList == null)
            {
                return Problem("Entity set 'MvcMovieContext.TierList'  is null.");
            }

            var tierLists = from m in _context.TierList
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                tierLists = tierLists.Where(s => s.Name!.Contains(searchString));
            }

            return View(await tierLists.ToListAsync());
        }

        // GET: TierLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TierList == null)
            {
                return NotFound();
            }

            var tierList = await _context.TierList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tierList == null)
            {
                return NotFound();
            }

            return View(tierList);
        }

        // GET: TierLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TierLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Atribute,Tier,WikiUrl,ImageUrl")] TierList tierList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tierList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tierList);
        }

        // GET: TierLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TierList == null)
            {
                return NotFound();
            }

            var tierList = await _context.TierList.FindAsync(id);
            if (tierList == null)
            {
                return NotFound();
            }
            return View(tierList);
        }

        // POST: TierLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Atribute,Tier,WikiUrl,ImageUrl")] TierList tierList)
        {
            if (id != tierList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tierList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TierListExists(tierList.Id))
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
            return View(tierList);
        }

        // GET: TierLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TierList == null)
            {
                return NotFound();
            }

            var tierList = await _context.TierList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tierList == null)
            {
                return NotFound();
            }

            return View(tierList);
        }

        // POST: TierLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TierList == null)
            {
                return Problem("Entity set 'GenshinTierListContext.TierList'  is null.");
            }
            var tierList = await _context.TierList.FindAsync(id);
            if (tierList != null)
            {
                _context.TierList.Remove(tierList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TierListExists(int id)
        {
          return _context.TierList.Any(e => e.Id == id);
        }
    }
}
