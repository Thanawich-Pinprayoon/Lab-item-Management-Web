using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LabManage.Data;
using LabManage.Models;

namespace LabManage.Controllers
{
    [Authorize(Policy = "ManageLab")]
    public class BlacklistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlacklistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blacklists
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var blacklist = _context.Blacklist.Include(b => b.lab).Include(b => b.staff).Include(b => b.user);
            return View(await blacklist.ToListAsync());
        }

        // GET: Blacklists/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.Blacklist
                .Include(b => b.lab)
                .Include(b => b.staff)
                .Include(b => b.user)
                .FirstOrDefaultAsync(m => m.userID == id);
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
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userID,staffID,labID,reason,date")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blacklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["labID"] = new SelectList(_context.Lab, "id", "name", blacklist.labID);
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", blacklist.userID);
            return View(blacklist);
        }

        // GET: Blacklists/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", blacklist.userID);
            return View(blacklist);
        }

        // POST: Blacklists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,userID,staffID,labID,reason,date")] Blacklist blacklist)
        {
            if (id != blacklist.userID)
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
                    if (!BlacklistExists(blacklist.userID))
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
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", blacklist.staffID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", blacklist.userID);
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.Blacklist
                .Include(b => b.lab)
                .Include(b => b.staff)
                .Include(b => b.user)
                .FirstOrDefaultAsync(m => m.userID == id);
            if (blacklist == null)
            {
                return NotFound();
            }

            return View(blacklist);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blacklist = await _context.Blacklist.FindAsync(id);
            _context.Blacklist.Remove(blacklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlacklistExists(string id)
        {
            return _context.Blacklist.Any(e => e.userID == id);
        }
    }
}
