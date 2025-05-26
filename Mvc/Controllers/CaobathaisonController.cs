using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class CaobathaisonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaobathaisonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caobathaison
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caobathaison.ToListAsync());
        }

        // GET: Caobathaison/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caobathaison = await _context.Caobathaison
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caobathaison == null)
            {
                return NotFound();
            }

            return View(caobathaison);
        }

        // GET: Caobathaison/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caobathaison/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sdt")] Caobathaison caobathaison)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caobathaison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caobathaison);
        }

        // GET: Caobathaison/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caobathaison = await _context.Caobathaison.FindAsync(id);
            if (caobathaison == null)
            {
                return NotFound();
            }
            return View(caobathaison);
        }

        // POST: Caobathaison/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Sdt")] Caobathaison caobathaison)
        {
            if (id != caobathaison.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caobathaison);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaobathaisonExists(caobathaison.Id))
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
            return View(caobathaison);
        }

        // GET: Caobathaison/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caobathaison = await _context.Caobathaison
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caobathaison == null)
            {
                return NotFound();
            }

            return View(caobathaison);
        }

        // POST: Caobathaison/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var caobathaison = await _context.Caobathaison.FindAsync(id);
            if (caobathaison != null)
            {
                _context.Caobathaison.Remove(caobathaison);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaobathaisonExists(string id)
        {
            return _context.Caobathaison.Any(e => e.Id == id);
        }
    }
}
