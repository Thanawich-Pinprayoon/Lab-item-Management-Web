using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Item
    {
        public int id { get; set; }

        [Required]
        public int toolID { get; set; }
        [Required]
        [ForeignKey("toolID")]
        public Tool tool { get; set; } 
    }
}