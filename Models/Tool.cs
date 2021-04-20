using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Tool
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        
        [Display(Name = "Tool Picture")]
        public string pic { get; set; }

        [Required]
        [Display(Name = "Store in Lab")]
        public int labID { get; set; }
        [ForeignKey("labID")]
        public Lab lab { get; set; }
    }
}