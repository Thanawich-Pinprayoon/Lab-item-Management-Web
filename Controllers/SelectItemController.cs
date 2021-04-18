using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab_item_Management_Web.Models;
using Microsoft.EntityFrameworkCore;
using Lab_item_Management_Web.Data;

namespace Lab_item_Management_Web.Controllers
{
    public class SelectItemController : Controller
    {
        private readonly LabItemManagementContext _context;

        public SelectItemController(LabItemManagementContext context)
        {
            _context = context;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            // var labs = await _context.Lab.ToListAsync();
            var labs = await _context.Lab.FindAsync(id);
            // var tools = await _context.Tool.ToListAsync();
            var tools = await _context.Tool.FindAsync(id);

            dynamic result = new {
                Id = labs.Id,
                Name = labs.Name,
                Description = labs.Description,
                Picture = labs.Picture,
                ToolName = tools.Name,
                Amount = tools.ItemAmount,
                ToolPicture = tools.Picture,
                ItemDesc = tools.Description,
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
        public async Task<IActionResult> EditLab(int id, [Bind("Id,Name,Description,Picture")] Lab lab)
        {
            if (id != lab.Id)
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
                    if (!LabExists(lab.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/SelectItem/Index/{lab.Id}");
            }
            return View(lab);
        }
        private bool LabExists(int id)
        {
            return _context.Lab.Any(e => e.Id == id);
        }


    }
}
