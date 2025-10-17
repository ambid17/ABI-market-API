using abi_market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace abi_market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController: ControllerBase
    {
        private readonly ILogger<MarketController> _logger;
        private readonly MarketContext _marketContext;
        
        public MarketController(ILogger<MarketController> logger, MarketContext marketContext)
        {
            _logger = logger;
            _marketContext = marketContext;
        }

        [HttpGet]
        [Route("getCategories")]
        public async Task<IEnumerable<ItemCategory>> GetItemCategories()
        {
            return await _marketContext.ItemCategories.Include(i => i.ItemSubcategories).ToListAsync();
        }

        [HttpGet]
        [Route("getItems")]
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _marketContext.Items.ToListAsync();
        }

        [HttpGet]
        [Route("item/{itemId}")]
        public async Task<Item> GetItemById(int itemId)
        {
            return await _marketContext.Items
                .Include(i => i.ItemPrices)
                .FirstOrDefaultAsync(item => item.Id == itemId)
                ?? new Item();
        }
        [HttpPost]
        [Route("addItem")]
        public async Task AddItem(Item item)
        {
            var existingItem = await _marketContext.Items.FirstOrDefaultAsync(existing => existing.Name == item.Name);
            if(existingItem != null)
            {
                return;
            }
            _marketContext.Items.Add(item);
            await _marketContext.SaveChangesAsync();
        }

        [HttpPost]
        [Route("addPrice")]
        public async Task AddItemPrice([FromBody] ItemPrice itemPrice)
        {
            var existingItem = await _marketContext.Items.FirstOrDefaultAsync(i => i.Id == itemPrice.ItemId);
            if(existingItem == null || itemPrice.Price <= 0)
            {
                return;
            }
            itemPrice.Date = DateTime.UtcNow;
            _marketContext.ItemPrices.Add(itemPrice);
            await _marketContext.SaveChangesAsync();
        }

        [HttpPost]
        [Route("deletePrice/{itemPriceId}")]
        public async Task DeleteItemPrice(int itemPriceId)
        {
            var existingItem = await _marketContext.ItemPrices.FirstOrDefaultAsync(i => i.Id == itemPriceId);
            if (existingItem == null)
            {
                return;
            }
            _marketContext.ItemPrices.Remove(existingItem);
            await _marketContext.SaveChangesAsync();
        }
    }
}
