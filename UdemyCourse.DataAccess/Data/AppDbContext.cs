using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UdemyCourse.Models;

namespace UdemyCourse.DataAccess.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }

   
}
