
using Microsoft.EntityFrameworkCore;

namespace task2_FiratKahreman.Models
{
    public class EventContext : DbContext
    {
        public EventContext() { }
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasOne(a => a.Category)
                .WithMany(b => b.CategoryActivities)
                .HasForeignKey(a => a.CategoryId);

                entity.HasOne(a => a.City)
                .WithMany(b => b.CityActivities)
                .HasForeignKey(a => a.CityId);

                entity.HasMany(a => a.SellerCompanies)
                .WithMany(b => b.CompanyActivities);

                entity.HasMany(a => a.AttendedUsers)
                .WithMany(b => b.AttendedActivities);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(a => a.AttendedActivities)
                .WithMany(b => b.AttendedUsers);

                entity.HasOne(a => a.Role)
                .WithMany(b => b.RoleUsers)
                .HasForeignKey(a => a.RoleId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\Firat;Database=EventDb;Trusted_Connection=True;");
            }
        }
    }
}
