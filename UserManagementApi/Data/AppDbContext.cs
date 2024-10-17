using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public async Task ClearDatabaseAsync()
        {
            Users.RemoveRange(Users);
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await Users.FirstOrDefaultAsync(u => u.Username == username);
        }

    }
}
