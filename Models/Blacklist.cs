using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Blacklist
    {
        public int id { get; set; }

        [Required]
        public int userID { get; set; }
        [Required]
        [ForeignKey("userID")]
        public virtual User user { get; set; } 

        [Required]
        public int staffID { get; set; }
        [Required]
        [ForeignKey("staffID")]
        public virtual User staff { get; set; }

        [Required]
        public string reason { get; set; }

        [Required]
        public int labID { get; set; }
        [Required]
        [ForeignKey("labID")]
        public Lab lab { get; set; }

        [Required]
        public string date { get; set; }
    }
}