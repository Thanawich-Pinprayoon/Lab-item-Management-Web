using Microsoft.AspNetCore.Http;

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
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(){
            HttpContext.Session.SetString("username","Ming.abc");
            return Redirect("/SelectLab");

        }
        public IActionResult Logout(){
            HttpContext.Session.SetString("username","");
            return Redirect("/SelectLab");
        }

    }
}
