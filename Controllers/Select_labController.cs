using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab_item_Management_Web.Models;

namespace Lab_item_Management_Web.Controllers
{
    public class Select_labController : Controller
    {
        private readonly ILogger<Select_labController> _logger;

        public Select_labController(ILogger<Select_labController> logger)
        {
            _logger = logger;
        }

        public IActionResult Select_lab()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
