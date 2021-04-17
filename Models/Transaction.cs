using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Transaction
    {
        public int id { get; set; }

        [Required]
        public int userID { get; set; }
        [Required]
        [ForeignKey("userID")]
        public virtual User user { get; set; } 

        public int staffID { get; set; }
        [ForeignKey("staffID")]
        public virtual User staff { get; set; }

        [Required]
        public int toolID { get; set; }
        [Required]
        [ForeignKey("toolID")]
        public virtual Tool tool { get; set; }

        public int itemID { get; set; }
        [ForeignKey("itemID")]
        public virtual Item item { get; set; }

        [Required]
        public DateTime start { get; set; }

        [Required]
        public DateTime end { get; set; }
        
        [Required]
        public int status { get; set; }
        // todo : reason for book
    }
}