using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string tel { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public string pic { get; set; }

        public int manageLabID { get; set; }
        [ForeignKey("manageLabID")]
        public virtual Lab manage { get; set; }
    }
}