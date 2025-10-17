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
        [Route("item")]
        public async Task<Item> GetItemById(int itemId)
        {
            return await _marketContext.Items.FirstOrDefaultAsync(item => item.Id == itemId) ?? new Item();
        }
        [HttpPost]
        [Route("addItem")]
        public async Task AddItem(Item item)
        {
            var existingItem = _marketContext.Items.FirstOrDefault(existing => existing.Name == item.Name);
            if(existingItem != null)
            {
                return;
            }
            _marketContext.Items.Add(item);
            await _marketContext.SaveChangesAsync();
        }

        [HttpPost]
        [Route("addPrice")]
        public async Task AddItemPrice(int itemId, decimal price)
        {
            var newItemPrice = new ItemPrice
            {
                ItemId = itemId,
                Price = price,
                Date = DateTime.Now
            };
            _marketContext.ItemPrices.Add(newItemPrice);
            await _marketContext.SaveChangesAsync();
        }
    }
}
