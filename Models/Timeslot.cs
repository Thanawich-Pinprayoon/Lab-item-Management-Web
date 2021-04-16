using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Timeslot
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; } 
        public int toolID { get; set; }
        public int count { get; set; }
    }
}