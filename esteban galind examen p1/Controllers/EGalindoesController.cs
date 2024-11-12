using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using esteban_galind_examen_p1.Data;
using esteban_galind_examen_p1.Models;

namespace esteban_galind_examen_p1.Controllers
{
    public class EGalindoesController : Controller
    {
        private readonly esteban_galind_examen_p1Context _context;

        public EGalindoesController(esteban_galind_examen_p1Context context)
        {
            _context = context;
        }

        // GET: EGalindoes
        public async Task<IActionResult> Index()
        {
            var esteban_galind_examen_p1Context = _context.EGalindo.Include(e => e.Celular);
            return View(await esteban_galind_examen_p1Context.ToListAsync());
        }

        // GET: EGalindoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGalindo = await _context.EGalindo
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eGalindo == null)
            {
                return NotFound();
            }

            return View(eGalindo);
        }

        // GET: EGalindoes/Create
        public IActionResult Create()
        {
            ViewData["CelularId"] = new SelectList(_context.Celular, "Id", "Modelo");
            return View();
        }

        // POST: EGalindoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Salario,Edad,Activo,FechaNacimiento,CelularId")] EGalindo eGalindo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eGalindo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelularId"] = new SelectList(_context.Celular, "Id", "Modelo", eGalindo.CelularId);
            return View(eGalindo);
        }

        // GET: EGalindoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGalindo = await _context.EGalindo.FindAsync(id);
            if (eGalindo == null)
            {
                return NotFound();
            }
            ViewData["CelularId"] = new SelectList(_context.Celular, "Id", "Modelo", eGalindo.CelularId);
            return View(eGalindo);
        }

        // POST: EGalindoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Salario,Edad,Activo,FechaNacimiento,CelularId")] EGalindo eGalindo)
        {
            if (id != eGalindo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eGalindo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EGalindoExists(eGalindo.Id))
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
            ViewData["CelularId"] = new SelectList(_context.Celular, "Id", "Modelo", eGalindo.CelularId);
            return View(eGalindo);
        }

        // GET: EGalindoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGalindo = await _context.EGalindo
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eGalindo == null)
            {
                return NotFound();
            }

            return View(eGalindo);
        }

        // POST: EGalindoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eGalindo = await _context.EGalindo.FindAsync(id);
            if (eGalindo != null)
            {
                _context.EGalindo.Remove(eGalindo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EGalindoExists(int id)
        {
            return _context.EGalindo.Any(e => e.Id == id);
        }
    }
}
