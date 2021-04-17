using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public enum Status
    {
        Book, Borrow, Return, Cancel
    }
    public class Transaction
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "User")]
        public int userID { get; set; }
        [Required]
        [ForeignKey("userID")]
        public virtual User user { get; set; } 

        [Display(Name = "Give by staff")]
        public int? staffID { get; set; }
        [ForeignKey("staffID")]
        public virtual User staff { get; set; }

        [Required]
        [Display(Name = "Tool")]
        public int toolID { get; set; }
        [Required]
        [ForeignKey("toolID")]
        public virtual Tool tool { get; set; }

        [Display(Name = "Item")]
        public int? itemID { get; set; }
        [ForeignKey("itemID")]
        public virtual Item item { get; set; }

        [Required]
        [Display(Name = "Borrow start")]
        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }

        [Required]
        [Display(Name = "Borrow end")]
        [DataType(DataType.DateTime)]
        public DateTime end { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public Status status { get; set; }
        // todo : reason for book
    }
}