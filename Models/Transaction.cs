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

        [Required]
        [Display(Name = "Tool")]
        public int toolID { get; set; }
        [ForeignKey("toolID")]
        public virtual Tool tool { get; set; }

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