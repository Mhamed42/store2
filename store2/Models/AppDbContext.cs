using Microsoft.EntityFrameworkCore;

namespace store2.Models
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Products> products { get; set; }
    }
}
