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

namespace Lab_item_Management_Web.Controllers
{
    public class BlackListController : Controller
    {
        private readonly MyProjectContext _context;

        public BlackListController(MyProjectContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            // ViewData["blackList"] = blackList;
            var db = new MyProjectContext();
            var blackList = db.BlackList.ToList();
            return View(blackList);
        }
        private bool BlackListExists(int id)
        {
            return _context.BlackList.Any(e => e.Id == id);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blacklist = await _context.BlackList.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,userID,addDate,reason,staffID,labName")] BlackListModel blacklist)
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