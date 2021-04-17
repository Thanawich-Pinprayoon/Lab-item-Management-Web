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
        public int userID { get; set; }
        [Required]
        [ForeignKey("userID")]
        public virtual User user { get; set; } 

        [Required]
        [Display(Name = "Blacklist By")]
        public int staffID { get; set; }
        [Required]
        [ForeignKey("staffID")]
        public virtual User staff { get; set; }

        [Required]
        [Display(Name = "Blacklist Reason")]
        public string reason { get; set; }

        [Required]
        [Display(Name = "Blacklist From Lab")]
        public int labID { get; set; }
        [Required]
        [ForeignKey("labID")]
        public Lab lab { get; set; }

        [Required]
        [Display(Name = "Blacklist At")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
    }
}