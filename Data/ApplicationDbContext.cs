using System; 
using System.Collections.Generic; 
using System.Text; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore; 
using LabManage.Models;
 
namespace LabManage.Data 
{ 
    public class ApplicationDbContext : IdentityDbContext<Users>
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
        } 
        public DbSet<Lab> Lab { get; set; }  
        public DbSet<Tool> Tool { get; set; }  
        public DbSet<Transaction> Transaction { get; set; }  
        public DbSet<Blacklist> Blacklist { get; set; }  
  

    } 
} 
