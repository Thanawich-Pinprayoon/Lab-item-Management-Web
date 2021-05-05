using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabManage.Data;
using LabManage.Models;

namespace Lab_item_Management_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LabApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemsAPI
        [HttpGet]
        public async Task<ActionResult<IList<Api>>> GetItem()
        {
            IList<Api> labApi = new Api[5];
            var labs = await _context.Lab.ToListAsync();
            var tools = await _context.Tool.ToListAsync();

            for (var i=0 ; i<labs.Count() ;i++)
            {
                Api api = new Api();
                api.itemName = tools[i].name;
                api.labName = labs[i].name;
                api.labImage = labs[i].pic;
                api.itemAmount = tools[i].amount;
                api.link = String.Format("http://lab-m.herokuapp.com/SelectItem/Index/{0}",i+1);
                labApi[i] = api;

            }
            
            return labApi.ToList();
        }

        // GET: api/ItemsAPI/5

    }
}
