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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

using System.Net.Http;

namespace LabManage.Controllers
{
    public class SelectLabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelectLabController(ApplicationDbContext context)//Contructure
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var labs = await _context.Lab.ToListAsync();

            var tools = await _context.Tool.ToListAsync();

            var trans = await _context.Transaction.ToListAsync();

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

        [Authorize]
        public async Task<IActionResult> CoLab()
        {
            string baseUrl = "https://dnzstudio.herokuapp.com/lab/getdata";
            var json = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data == null) json = "[]";
                            json = data;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                json = "[]";
            }
            var colab = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Api>>(json);
            ViewBag.item = colab ;
            return View();
        }
    }
}
