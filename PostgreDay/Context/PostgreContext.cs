using Microsoft.EntityFrameworkCore;
using PostgreDay.Entities;

namespace PostgreDay.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
