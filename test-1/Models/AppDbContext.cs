using Microsoft.EntityFrameworkCore;
using test_1.Models;


namespace test_1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } // DbSet representing your Items table

        // Add DbSet properties for other tables if needed
    }
}
