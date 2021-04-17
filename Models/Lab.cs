using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Lab
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        
        [Display(Name = "Lab Picture")]
        public string pic { get; set; }
    }
}