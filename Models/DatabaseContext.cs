using Microsoft.EntityFrameworkCore;
using Lab_item_Management_Web.Models;

namespace Lab_item_Management_Web.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Blacklist> Blacklist { get; set; }
    }
}