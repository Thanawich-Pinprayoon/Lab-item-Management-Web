using Microsoft.EntityFrameworkCore;
using LabManage.Models;

namespace LabManage.Data
{
    public class LabManageContext : DbContext
    {
        public LabManageContext (DbContextOptions<LabManageContext> options)
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
            modelBuilder.Entity<Timeslot>()
                //.HasNoKey();
                .HasKey(t => new {t.start, t.end, t.toolID});
        }
    }
}