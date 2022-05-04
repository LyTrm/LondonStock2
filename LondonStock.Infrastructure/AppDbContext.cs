using LondonStock.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public AppDbContext()
        {

        }

        public DbSet<Trade>? Trades { get; set; }
        public DbSet<Stock>? Stocks { get; set; }

    }
}
