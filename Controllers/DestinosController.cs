﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaComBack.Models;

namespace AgenciaComBack.Controllers
{
    public class DestinosController : Controller
    {
        private readonly Context _context;

        public DestinosController(Context context)
        {
            _context = context;
        }

        // GET: Destinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.destino.ToListAsync());
        }

        // GET: Destinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destino
                .FirstOrDefaultAsync(m => m.IdDestino == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // GET: Destinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDestino,NomeDestino,Date")] Destino destino)
        {

            _context.Add(destino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Destinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destino.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDestino,NomeDestino,Date")] Destino destino)
        {
            if (id != destino.IdDestino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoExists(destino.IdDestino))
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
            return View(destino);
        }

        // GET: Destinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.destino
                .FirstOrDefaultAsync(m => m.IdDestino == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destino = await _context.destino.FindAsync(id);
            _context.destino.Remove(destino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoExists(int id)
        {
            return _context.destino.Any(e => e.IdDestino == id);
        }
    }
}
