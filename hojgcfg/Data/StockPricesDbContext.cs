using hojgcfg.Model;
using Microsoft.EntityFrameworkCore;

namespace hojgcfg.Data
{
	public class StockPricesDbContext : DbContext
	{
		public StockPricesDbContext(DbContextOptions<StockPricesDbContext> options) : base(options)
		{
		}
		public DbSet<StockPrice> stockPrices { get; set; }
	}
}
