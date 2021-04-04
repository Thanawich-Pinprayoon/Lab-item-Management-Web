using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab_item_Management_Web.Controllers
{
    public class BlackListController : Controller
    {
        private readonly ILogger<BlackListController> _logger;

        // public BlackListController(ILogger<BlackListController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult BlackList()
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