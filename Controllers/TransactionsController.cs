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

            transaction = transaction.Include(t => t.tool).Include(t => t.user);
            
            return View(await transaction.ToListAsync());
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
