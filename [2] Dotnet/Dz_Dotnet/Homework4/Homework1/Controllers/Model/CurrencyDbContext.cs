using Microsoft.EntityFrameworkCore;

namespace Homework1.Controllers.Model
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Currency> Currency { get; set; }

    }
}
