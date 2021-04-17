using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class Timeslot
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime start { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime end { get; set; } 

        [Required]
        public int toolID { get; set; }
        [Required]
        [ForeignKey("toolID")]
        public Tool tool { get; set; }

        [Required]
        public int count { get; set; }
    }
}