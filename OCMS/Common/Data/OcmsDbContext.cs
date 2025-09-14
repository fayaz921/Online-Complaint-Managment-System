using Microsoft.EntityFrameworkCore;
using OCMS.Models;
using System.Configuration;

namespace OCMS.Common.CustomClasses.Data
{
    public class OcmsDbContext:DbContext
    {
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                var conn = ConfigurationManager.ConnectionStrings["ocmsConn"].ConnectionString;
                optionsBuilder.UseSqlServer(conn);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCreadential> UsersCreadentials { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintResponse>  ComplaintResponses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
} 