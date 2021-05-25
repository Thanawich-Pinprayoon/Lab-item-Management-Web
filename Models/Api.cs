using System;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Models
{
    public class Api
    {

        public string labName { get; set; }
        public string itemName { get; set; }
        public string labImage { get; set; }
        public int itemAmount { get; set; }
        public string link { get; set; }

    }
}