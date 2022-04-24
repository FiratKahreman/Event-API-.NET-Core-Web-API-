
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
                .WithMany(b => b.ActivitiesCategories)
                .HasForeignKey(a => a.CategoryId);

                entity.HasOne(a => a.City)
                .WithMany(b => b.ActivitiesCities)
                .HasForeignKey(a => a.CityId);

                entity.HasMany(a => a.Companies)
                .WithMany(b => b.CompanyActivities);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(a => a.Activities)
                .WithMany(b => b.ActivitiesUsers);
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
