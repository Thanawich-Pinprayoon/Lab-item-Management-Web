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
    public class BlackListController : Controller
    {
        public ActionResult Index()
        {
            // ViewData["blackList"] = blackList;
            var db = new MyProjectContext();
            var blackList = db.BlackList.ToList();
            return View(blackList);
        }
    }

}