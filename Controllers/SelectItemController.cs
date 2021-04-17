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

            return View(lab);
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }
    }
}
