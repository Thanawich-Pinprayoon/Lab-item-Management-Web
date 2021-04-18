using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LabManage.Data
{
    // Add profile data for application users by adding properties to the Users class
    public class Users : IdentityUser
    {
        [Required]
        [PersonalData]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [PersonalData]
        [Display(Name = "Profile Picture")]
        public string Pic { get; set; }
    }
}
