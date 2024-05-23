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
        public DbSet<ProductOrder>ProductOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<Termin> Termins { get; set; }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("YourConnectionStringHere")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Debug);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

       

            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            // Configure the relationship between ProductOrder and OrderEntity
            builder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);

            // Configure the relationship between ProductOrder and Product
            builder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);
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