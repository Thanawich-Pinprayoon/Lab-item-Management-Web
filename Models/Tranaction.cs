using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Tranaction
    {
        public int id { get; set; }
        public int userID { get; set; } 
        public int staffID { get; set; }
        public int toolID { get; set; }
        public int itemID { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int status { get; set; }
        // todo : reason for book
    }
}