using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Tool
    {
        public int id { get; set; }
        public string name { get; set; } 
        public string description { get; set; }
        public string picture { get; set; }
        public int labID { get; set; }
    }
}