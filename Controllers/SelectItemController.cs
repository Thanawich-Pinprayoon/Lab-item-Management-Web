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
            var labs = await _context.Lab.Where(m=>m.Id == id ).ToListAsync();
            // var tools = await _context.Tool.ToListAsync();
            var tools = await _context.Tool.Where(m=>m.LabID == id ).ToListAsync();

            List<dynamic> result = new List<dynamic>();
            result.Add(new 
            {
                Id = labs.ElementAt(0).Id,
                Name = labs.ElementAt(0).Name,
                Description = labs.ElementAt(0).Description,
                Picture = labs.ElementAt(0).Picture,
                ToolName = tools.ElementAt(0).Name,
                Amount = tools.ElementAt(0).ItemAmount,
                ItemDesc = tools.ElementAt(0).Description,
            });
        

            ViewBag.item = result;

            return View(lab);
        }

        //  public async Task<IActionResult> Index()
        // {
           
        //     return View();
        // }


        // public IActionResult Privacy()
        // {
        //     return View();
        // }
    }
}
