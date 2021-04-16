using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_item_Management_Web.Models
{
    public class Blacklist
    {
        public int id { get; set; }
        public int userID { get; set; }
        public DateTime? addDate { get; set; }
        public string reason { get; set; }
        public int staffID { get; set; }
        public string labName { get; set;}
    }
}