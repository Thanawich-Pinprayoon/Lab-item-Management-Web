using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_item_Management_Web.Data;
using Lab_item_Management_Web.Models;

namespace Lab_item_Management_Web.Controllers
{
    public class ToolController : Controller
    {
        private readonly LabItemManagementContext _context;

        public ToolController(LabItemManagementContext context)
        {
            _context = context;
        }

        // GET: Tool
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tool.ToListAsync());
        }

        // GET: Tool/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tool/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tool/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Picture,LabID,ItemAmount")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tool);
        }

        // GET: Tool/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }
            return View(tool);
        }

        // POST: Tool/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Picture,LabID,ItemAmount")] Tool tool)
        {
            if (id != tool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(tool.Id))
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
            return View(tool);
        }

        // GET: Tool/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tool = await _context.Tool.FindAsync(id);
            _context.Tool.Remove(tool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolExists(int id)
        {
            return _context.Tool.Any(e => e.Id == id);
        }
    }
}
