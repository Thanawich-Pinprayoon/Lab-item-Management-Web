using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LabManage.Data;
using LabManage.Models;

namespace LabManage.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionsController(ApplicationDbContext context,
            UserManager<Users> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var transaction = _context.Transaction.AsQueryable();

            if (_httpContextAccessor.HttpContext.User.HasClaim(c => c.Type == "ManageLab")) {
                var c = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "ManageLab");
                transaction = transaction.Where(t => (t.tool.labID == Int32.Parse(c.Value)) || (t.userID == currentUser.Id));
            } else {
                transaction = transaction.Where(t => t.userID == currentUser.Id);
            }

            transaction = transaction.Include(t => t.staff).Include(t => t.tool).Include(t => t.user);
            
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

        // GET: Transactions/CreateNew
        public IActionResult Create()
        {
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name");
            return View();
        }

        // POST: Transactions/CreateNew
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("toolID,start,end")] Transaction transaction)
        {
            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.userID = currentUser.Id;
            transaction.status = Status.Book;

            if (TryValidateModel(transaction, nameof(transaction)))
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        [Authorize(Policy = "ManageLab")]
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
            var currentUser = await _userManager.GetUserAsync(User);
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", transaction.staffID);
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", transaction.userID);
            ViewData["status"] = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Book", Value = ((int)Status.Book).ToString()},
                    new SelectListItem { Text = "Borrow", Value = ((int)Status.Borrow).ToString()},
                    new SelectListItem { Text = "Cancel", Value = ((int)Status.Cancel).ToString()},
                    new SelectListItem { Text = "Return", Value = ((int)Status.Return).ToString()},
                }, "Value" , "Text", transaction.status);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManageLab")]
        public async Task<IActionResult> Edit(int id, [Bind("id,userID,staffID,toolID,itemID,start,end,status")] Transaction transaction)
        {
            if (id != transaction.id)
            {
                return NotFound();
            }

            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.staffID = currentUser.Id;

            if (TryValidateModel(transaction, nameof(transaction)))
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
            ViewData["staffID"] = new SelectList(_context.Users, "Id", "Name", transaction.staffID);
            ViewData["toolID"] = new SelectList(_context.Tool, "id", "name", transaction.toolID);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "Name", transaction.userID);
            ViewData["status"] = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Book", Value = ((int)Status.Book).ToString()},
                    new SelectListItem { Text = "Borrow", Value = ((int)Status.Borrow).ToString()},
                    new SelectListItem { Text = "Cancel", Value = ((int)Status.Cancel).ToString()},
                    new SelectListItem { Text = "Return", Value = ((int)Status.Return).ToString()},
                }, "Value" , "Text", transaction.status);
            return View(transaction);
        }

        // GET: Transactions/Give/5
        [Authorize(Policy = "ManageLab")]
        public async Task<IActionResult> Give(int? id)
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

            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.staffID = currentUser.Id;
            transaction.status = Status.Borrow;

            if (TryValidateModel(transaction, nameof(transaction)))
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
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Grab/5
        [Authorize(Policy = "ManageLab")]
        public async Task<IActionResult> Grab(int? id)
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

            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.staffID = currentUser.Id;
            transaction.status = Status.Return;

            if (TryValidateModel(transaction, nameof(transaction)))
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
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
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

            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.status = Status.Cancel;

            if (TryValidateModel(transaction, nameof(transaction)))
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
            
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.id == id);
        }
    }
}
