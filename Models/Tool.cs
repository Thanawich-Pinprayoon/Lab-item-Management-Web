using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Tool
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }
        
        public string picture { get; set; }

        [Required]
        public int labID { get; set; }
        [Required]
        [ForeignKey("labID")]
        public Lab lab { get; set; }
    }
}