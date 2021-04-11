using System;
using Microsoft.EntityFrameworkCore;

namespace Lab_item_Management_Web.Models
{
    public class MyProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database/myDB.db");
        }

        public DbSet<BlackListModel> Movie { get; set; }
    }
}