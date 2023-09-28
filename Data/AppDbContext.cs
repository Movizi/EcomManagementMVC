using EcomManagement.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace EcomManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
