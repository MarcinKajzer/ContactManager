using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI.Entities
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Email);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<SubCategory>()
                .HasKey(sc => sc.Id);


            modelBuilder.Entity<Contact>(eb =>
            {
                eb.Property(c => c.Email).IsRequired().HasMaxLength(100);
                eb.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
                eb.Property(c => c.LastName).IsRequired().HasMaxLength(100);
                eb.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(9);   
                eb.Property(c => c.DateOfBirth).IsRequired();

                eb.HasOne(c => c.Category)
                .WithMany(cat => cat.Contacts)
                .HasForeignKey(c => c.CategoryId);

                eb.HasOne(c => c.SubCategory)
                .WithMany(cat => cat.Contacts)
                .HasForeignKey(c => c.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Category>(eb =>
            {
                eb.Property(c => c.Name).IsRequired().HasMaxLength(100);

                eb.HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId);
            });

            modelBuilder.Entity<SubCategory>(eb =>
            {
                eb.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
