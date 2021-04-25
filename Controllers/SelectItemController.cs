using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabManage.Models;
using Microsoft.EntityFrameworkCore;
using LabManage.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LabManage.Controllers
{
    public class SelectItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Users> _userManager;

        public SelectItemController(ApplicationDbContext context, UserManager<Users> userManager)
        {
            _context = context;
             _userManager = userManager;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }
    
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Lab
                .FirstOrDefaultAsync(m => m.id == id);
            if (lab == null)
            {
                return NotFound();
            }

            // var labs = await _context.Lab.ToListAsync();
            var labs = await _context.Lab.FindAsync(id);
            // var tools = await _context.Tool.ToListAsync();
            var tools = await _context.Tool.FindAsync(id);

            dynamic result = new {
                Id = labs.id,
                Name = labs.name,
                Description = labs.description,
                Picture = labs.pic,
                ToolId= tools.id,
                ToolName = tools.name,
                ToolLabId= tools.labID,
                Amount = tools.amount,
                ToolPicture = tools.pic,
                ItemDesc = tools.description,
            };

            
        
            ViewBag.item = result;

            return View();
        }

        
        // GET: User/Edit/5
        public async Task<IActionResult> EditLab(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Lab.FindAsync(id);
            if (lab == null)
            {
                return NotFound();
            }
            return View(lab);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLab(int id, [Bind("id,name,description,pic")] Lab lab)
        {
            if (id != lab.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabExists(lab.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/SelectItem/Index/{lab.id}");
            }
            return View(lab);
        }

          // GET: User/Edit/5
        public async Task<IActionResult> EditTool(int? id)
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

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTool(int id, [Bind("id,name,description,pic,labID,amount")] Tool tool)
        {
            if (id != tool.id)
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
                    if (!LabExists(tool.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/SelectItem/Index/{tool.id}");
            }
            return View(tool);
        }

        // POST: Transactions/CreateNew
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction( [Bind("toolID,start,end")] Transaction transaction)
        {
            ModelState.Clear();

            var currentUser = await _userManager.GetUserAsync(User);
            transaction.userID = currentUser.Id;
            transaction.status = Status.Book;

            if (TryValidateModel(transaction, nameof(transaction)))
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return Redirect($"/SelectItem/Index/{transaction.toolID}");
            }
            
            return View(transaction);
        }
        private bool ToolExists(int id)
        {
            return _context.Lab.Any(e => e.id == id);
        }
        private bool LabExists(int id)
        {
            return _context.Lab.Any(e => e.id == id);
        }


    }
}
