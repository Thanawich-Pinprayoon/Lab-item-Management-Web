using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab_item_Management_Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using Lab_item_Management_Web.Data;

namespace Lab_item_Management_Web.Controllers
{
    public class LabController : Controller
    {
         //ไว้เชื่อม DB
        private readonly LabItemManagementContext _context;

        public LabController(LabItemManagementContext context)//Contructure
        {
            _context = context;
        }
        
        
        // public IActionResult Index()
        // {
        //     return View();
        // }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lab.ToListAsync());
        }

    }
}
