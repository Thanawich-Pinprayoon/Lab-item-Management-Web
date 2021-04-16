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
    }
}