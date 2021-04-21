using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Lab_item_Management_Web.Models;

using Lab_item_Management_Web.Data;

namespace Lab_item_Management_Web.Controllers
{
    public class BlackListController : Controller
    {
        private readonly LabItemManagementContext _context;

        public BlackListController(LabItemManagementContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            //ViewData["blackList"] = blackList;
            // var db = new LabItemManagementContext();
            var blacklist =  _context.Blacklist.ToList();
            return View(blacklist);
        }
        private bool BlackListExists(int id)
        {
            return _context.Blacklist.Any(e => e.Id == id);
        }

        // GET: Movies/Edit/5
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
            return View(blacklist);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,userID,addDate,reason,staffID,labId")] Blacklist blacklist)
        {
            if (id != blacklist.Id)
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
                    if (!BlackListExists(blacklist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blacklist);
        }
    }

}