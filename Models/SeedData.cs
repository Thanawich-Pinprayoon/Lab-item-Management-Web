using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lab_item_Management_Web.Data;
using System;
using System.Linq;

namespace Lab_item_Management_Web.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyProjectContext(
                // serviceProvider.GetRequiredService<
                //     DbContextOptions<MyProjectContext>>()
                )
                )
            {
                // Look for any movies.
                if (context.BlackList.Any())
                {
                    return;   // DB has been seeded
                }

                context.BlackList.AddRange(
                    new BlackListModel
                    {
                        userID = 312,
                        addDate = DateTime.Parse("1989-2-12"),
                        reason = "Ugly",
                        staffID = 123,
                        labName = "Computer Laboratory"
                    },

                    new BlackListModel
                    {
                        userID = 111,
                        addDate = DateTime.Parse("1989-2-12"),
                        reason = "Ugly",
                        staffID = 123,
                        labName = "Computer Laboratory"
                    },

                    new BlackListModel
                    {
                        userID = 112,
                        addDate = DateTime.Parse("1989-2-12"),
                        reason = "Ugly",
                        staffID = 123,
                        labName = "Computer Laboratory"
                    },

                    new BlackListModel
                    {
                        userID = 113,
                        addDate = DateTime.Parse("1989-2-12"),
                        reason = "Ugly",
                        staffID = 123,
                        labName = "Computer Laboratory"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}