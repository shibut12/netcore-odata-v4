using Microsoft.EntityFrameworkCore;

namespace ODataNetCore
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions options):base(options){ }

        public DbSet<Product> Products { get;set;}
    }
}