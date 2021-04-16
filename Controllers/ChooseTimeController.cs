using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab_item_Management_Web.Controllers
{
    public class ChooseTimeController : Controller
    {
        // private readonly ILogger<ChooseTimeController> _logger;

        // public ChooseTimeController(ILogger<ChooseTimeController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult index()
        {
            return View();
        }
        public IActionResult ChooseTime()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}