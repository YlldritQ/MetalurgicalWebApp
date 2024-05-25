using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace backend_dotnet7.Core.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<Product_Order> Product_Orders { get; set; }

        public DbSet<Termin> Termins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TerminLocation> TerminLocations { get; set; }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*  builder.Entity<Product_Order>()
                     .HasOne(p => p.Product)
                     .WithMany(po => po.Product_Orders)
                     .HasForeignKey(pi => pi.ProductId);

              builder.Entity<Product_Order>()
                   .HasOne(o => o.Order)
                   .WithMany(po => po.Product_Orders)
                   .HasForeignKey(oi => oi.OrderId);
            */
            builder.Entity<Product_Order>()
                  .HasKey(po => new { po.ProductId, po.OrderId });

            builder.Entity<TerminLocation>()
                .HasKey(tl => new { tl.TerminId, tl.LocationId });

            builder.Entity<OrderEntity>()
              .Property(o => o.Total)
              .HasColumnType("decimal(18, 2)");

            //1
            builder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("Users");
            });
            //2
            builder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("UserClaims");
            });
            //3
            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogins");
            });
            //4
            builder.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("UserTokens");
            });
            //5
            builder.Entity<IdentityRole>(e =>
            {
                e.ToTable("Roles");
            });
            //6
            builder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("RoleClaims");
            });
            //7
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRoles");
            });
        }
    }
}