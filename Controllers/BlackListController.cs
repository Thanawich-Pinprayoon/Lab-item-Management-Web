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
        public class BlacklistUser
    {
        public static DateTime RandomDay()
    {
        Random gen = new Random();
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }

    public static string GenerateName(int len)
    {
        Random r = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }
        return Name;
    }
        int userId;//data member (also instance variable)
        String userName;//data member(also instance variable)
        DateTime addDate;
        String reason;
        int staffID;


            public BlacklistUser(int id, String uname, DateTime date,int staffid, String reas)
        {
            userId = id;
            userName = uname;
            addDate = date;
            staffID = staffid;
            reason = reas;
        }
        
        public string getUserName(){
                return this.userName;
            }
        public string getAddDate(){
            return this.addDate.ToString("dd MMMM yyyy");
        }
        public int getUserId(){
            return this.userId;
        }
        public string getReason(){
            return this.reason;
        }
        public int getStaffID(){
            return this.staffID;
        }
    }   
        IList<BlacklistUser> blackList = new List<BlacklistUser>() { 
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12))),
            new BlacklistUser(new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)),BlacklistUser.RandomDay(),new Random().Next(100,999),BlacklistUser.GenerateName(new Random().Next(1,12)))
        };

        
        private readonly ILogger<BlackListController> _logger;

        // public BlackListController(ILogger<BlackListController> logger)
        // {
        //     _logger = logger;
        // }

        public ActionResult Index()
        {   
            ViewData["blackList"] = blackList;
            return View();
        }
        public IActionResult BlackList()
        {
            ViewData["blackList"] = blackList;
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
    
}