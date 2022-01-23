using Microsoft.EntityFrameworkCore;

namespace EpsicEFCoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Subjects)
                .WithOne(s => s.User)
                .HasForeignKey(u => u.UserId);
        }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
