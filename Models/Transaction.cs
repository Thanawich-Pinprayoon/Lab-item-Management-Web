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
        public string userID { get; set; }
        [ForeignKey("userID")]
        public virtual Users user { get; set; } 

        [Display(Name = "Give by staff")]
        public string staffID { get; set; }
        [ForeignKey("staffID")]
        public virtual Users staff { get; set; }

        [Required]
        [Display(Name = "Tool")]
        public int toolID { get; set; }
        [ForeignKey("toolID")]
        public virtual Tool tool { get; set; }

        [Required]
        [Display(Name = "Borrow start")]
        [DataType(DataType.Date)]
        public DateTime start { get; set; }

        [Required]
        [Display(Name = "Borrow end")]
        [DataType(DataType.Date)]
        public DateTime end { get; set; }

        [Required]
        [Display(Name = "date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        
        
        [Required]
        [Display(Name = "Status")]
        public Status status { get; set; }
        // todo : reason for book
    }
}