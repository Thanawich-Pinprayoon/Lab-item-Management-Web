using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Lab
    {
        public int id { get; set; }
        public string name { get; set; } 
        public string description { get; set; }
        public string pic { get; set; }
    }
}