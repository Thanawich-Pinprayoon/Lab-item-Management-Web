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
 
        public DbSet<User> User { get; set; }  
        public DbSet<Lab> Lab { get; set; }  
        public DbSet<Tool> Tool { get; set; }  
        public DbSet<Item> Item { get; set; }  
        public DbSet<Transaction> Transaction { get; set; }  
        public DbSet<Timeslot> Timeslot { get; set; }  
        public DbSet<Blacklist> Blacklist { get; set; }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            base.OnModelCreating(modelBuilder); 
             
            modelBuilder.Entity<Timeslot>()
                .HasKey(t => new {t.start, t.end, t.toolID});

            modelBuilder.Entity<Blacklist>()
                .HasKey(t => new {t.userID, t.staffID, t.labID});
        }  
    } 
} 
