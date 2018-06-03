using System.Data.Entity;
using LinkStart.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Connection> Connections { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");


        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}