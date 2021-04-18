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
    public class SelectLabController : Controller
    {
        // private readonly ILogger<Select_labController> _logger;

        // public Select_labController(ILogger<Select_labController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly LabItemManagementContext _context;

        public SelectLabController(LabItemManagementContext context)//Contructure
        {
            _context = context;
        }

        // public IActionResult Select_lab()
        // {
        //     return View();
        // }

        public async Task<IActionResult> Index()
        {
            var labs = await _context.Lab.ToListAsync();
            // var labs = await _context.Lab.Where(m=>m.Id == 1 ).ToListAsync(); Filter เอาแต่ Lab 1
            var tools = await _context.Tool.ToListAsync();

            List<dynamic> result = new List<dynamic>();

            for (var i = 0; i < labs.Count(); i++)
            {
                result.Add(new 
                {
                    Id = labs.ElementAt(i).Id,
                    Name = labs.ElementAt(i).Name,
                    Description = labs.ElementAt(i).Description,
                    Picture = labs.ElementAt(i).Picture,
                    ToolName = tools.ElementAt(i).Name,
                    Amount = tools.ElementAt(i).ItemAmount
                });
            }

            ViewBag.labTool= result;
            return View();
        }

            // GET: User/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: User/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Description,Picture")] Lab lab)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lab);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lab);
            }

             public IActionResult Edit()
            {
                return View();
            }



        }
    }
