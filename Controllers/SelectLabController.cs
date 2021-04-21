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

namespace LabManage.Controllers
{
    public class SelectLabController : Controller
    {
        // private readonly ILogger<Select_labController> _logger;

        // public Select_labController(ILogger<Select_labController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly ApplicationDbContext _context;

        public SelectLabController(ApplicationDbContext context)//Contructure
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
                    Id = labs.ElementAt(i).id,
                    Name = labs.ElementAt(i).name,
                    Description = labs.ElementAt(i).description,
                    Picture = labs.ElementAt(i).pic,
                    ToolName = tools.ElementAt(i).name,
                    Amount = tools.ElementAt(i).amount
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
            public async Task<IActionResult> Create([Bind("id,name,description,pic")] Lab lab)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lab);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lab);
            }


        }
    }
