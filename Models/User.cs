using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } 
        public string tel { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string pic { get; set; }
        public int manage { get; set; }
    }
}