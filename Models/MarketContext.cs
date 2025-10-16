using Microsoft.EntityFrameworkCore;

namespace abi_market.Models
{
    public class MarketContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemSubcategory> ItemSubcategories { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
        }
    }
}
