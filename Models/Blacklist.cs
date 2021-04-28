using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Blacklist
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "User")]
        public string userID { get; set; }
    
        [ForeignKey("userID")]
        public virtual Users user { get; set; } 

        [Required]
        [Display(Name = "Reason")]
        public string reason { get; set; }

    }
}