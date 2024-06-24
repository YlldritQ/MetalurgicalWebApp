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

        public DbSet<HeatTreatment> HeatTreatments { get; set; }
        public DbSet<Corrosion> Corrosions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<Product_Order> Product_Orders { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          
            builder.Entity<Product_Order>()
                  .HasKey(po => new { po.ProductId, po.OrderId });


            builder.Entity<Material>()
                .HasOne(m => m.Supplier)
                .WithMany(s => s.Materials)
                .HasForeignKey(m => m.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HeatTreatment>()
                .HasOne(ht => ht.Corrosion)
                .WithMany(c => c.HeatTreatments)
                .HasForeignKey(ht => ht.CorrosionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Project entity
            builder.Entity<Project>()
                .Property(p => p.ProjectId)
                .ValueGeneratedOnAdd(); // Auto-generate ProjectId

            builder.Entity<Project>()
                .Property(p => p.Budget)
                .HasColumnType("float"); // Ensure Budget is of type float

            // Configure ProjectTask entity
            builder.Entity<ProjectTask>()
                .Property(pt => pt.ProjectTaskId)
                .ValueGeneratedOnAdd(); // Auto-generate TaskId

            builder.Entity<ProjectTask>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTasks)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<OrderEntity>()
              .Property(o => o.Total)
              .HasColumnType("decimal(18, 2)");
////////////////////////////////////////////////////////
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