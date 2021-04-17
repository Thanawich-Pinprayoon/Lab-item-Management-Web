using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabManage.Data;
using LabManage.Models;

namespace Lab_item_Management_Web.Controllers
{
    public class BlacklistsController : Controller
    {
        private readonly LabManageContext _context;

        public BlacklistsController(LabManageContext context)
        {
            _context = context;
        }

        // GET: Blacklists
        public async Task<IActionResult> Index()
        {
            var blacklist = _context.Blacklist.Include(b => b.lab).Include(b => b.staff).Include(b => b.user);
            return View(await blacklist.ToListAsync());
        }

        // GET: Blacklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.Blacklist
                .Include(b => b.lab)
                .Include(b => b.staff)
                .Include(b => b.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (blacklist == null)
            {
                return NotFound();
            }

            return View(blacklist);
        }

        // GET: Blacklists/Create
        public IActionResult Create()
        {
            ViewData["labID"] = new SelectList(_context.Lab, "id", "name");
            ViewData["staffID"] = new SelectList(_context.User, "id", "name");
            ViewData["userID"] = new SelectList(_context.User, "id", "name");
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userID,staffID,reason,labID,date")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blacklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["labID"] = new SelectList(_context.Lab, "id", "name", blacklist.labID);
            ViewData["staffID"] = new SelectList(_context.User, "id", "name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.User, "id", "name", blacklist.userID);
            return View(blacklist);
        }

        // GET: Blacklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.Blacklist.FindAsync(id);
            if (blacklist == null)
            {
                return NotFound();
            }
            ViewData["labID"] = new SelectList(_context.Lab, "id", "name", blacklist.labID);
            ViewData["staffID"] = new SelectList(_context.User, "id", "name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.User, "id", "name", blacklist.userID);
            return View(blacklist);
        }

        // POST: Blacklists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userID,staffID,reason,labID,date")] Blacklist blacklist)
        {
            if (id != blacklist.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blacklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlacklistExists(blacklist.id))
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
            ViewData["labID"] = new SelectList(_context.Lab, "id", "name", blacklist.labID);
            ViewData["staffID"] = new SelectList(_context.User, "id", "name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.User, "id", "name", blacklist.userID);
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.Blacklist
                .Include(b => b.lab)
                .Include(b => b.staff)
                .Include(b => b.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (blacklist == null)
            {
                return NotFound();
            }

            return View(blacklist);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blacklist = await _context.Blacklist.FindAsync(id);
            _context.Blacklist.Remove(blacklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlacklistExists(int id)
        {
            return _context.Blacklist.Any(e => e.id == id);
        }
    }
}
