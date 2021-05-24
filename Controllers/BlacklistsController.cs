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
       
        public async Task<IActionResult> Index()
        {
            var blacklist = _context.Blacklist.Include(b => b.user);
            return View(await blacklist.ToListAsync());
        }

        // GET: Blacklists/Create
        public IActionResult Create()
        {
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userID,reason")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blacklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", blacklist.userID);
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            var blacklist = await _context.Blacklist
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

        private bool BlacklistExists(string id)
        {
            return _context.Blacklist.Any(e => e.userID == id);
        }
    }
}
