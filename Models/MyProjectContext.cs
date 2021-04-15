// using System;
// using Microsoft.EntityFrameworkCore;

// namespace Lab_item_Management_Web.Models
// {
//     public class MyProjectContext : DbContext
//     {
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseSqlite("Data source=Database/blacklist.db");
//         }

//         public DbSet<BlackListModel> BlackList { get; set; }
//     }
// }