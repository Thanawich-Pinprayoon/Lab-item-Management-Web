using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabManage.Data;
using LabManage.Models;

namespace LabManage.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transaction = _context.Transaction.Include(t => t.item).Include(t => t.staff).Include(t => t.tool).Include(t => t.user);
            return View(await transaction.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.item)
                .Include(t => t.staff)
                .Include(t => t.tool)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["itemID"] = new SelectList(_context.Item, "id", "id");
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name");
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userID,staffID,toolID,itemID,start,end,status")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["itemID"] = new SelectList(_context.Item, "id", "id", transaction.itemID);
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", transaction.staffID);
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", transaction.userID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["itemID"] = new SelectList(_context.Item, "id", "id", transaction.itemID);
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", transaction.staffID);
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", transaction.userID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userID,staffID,toolID,itemID,start,end,status")] Transaction transaction)
        {
            if (id != transaction.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.id))
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
            ViewData["itemID"] = new SelectList(_context.Item, "id", "id", transaction.itemID);
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", transaction.staffID);
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", transaction.userID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.item)
                .Include(t => t.staff)
                .Include(t => t.tool)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.id == id);
        }
    }
}
