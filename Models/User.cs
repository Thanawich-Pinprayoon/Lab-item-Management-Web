using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManage.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Display(Name = "Telephone")]
        public string tel { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Profile Picture")]
        public string pic { get; set; }

        [Display(Name = "Manage Lab")]
        public int? manageLabID { get; set; }
        [ForeignKey("manageLabID")]
        public virtual Lab manage { get; set; }
    }
}