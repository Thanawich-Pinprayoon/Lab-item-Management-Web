using Microsoft.EntityFrameworkCore;
using Lab_item_Management_Web.Models;

namespace Lab_item_Management_Web.Data
{
    public class LabItemManagementContext : DbContext
    {
        public LabItemManagementContext (DbContextOptions<LabItemManagementContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Lab> Lab { get; set; }
        public DbSet<Tool> Tool { get; set; }
    }
}
//ตัวกลาง