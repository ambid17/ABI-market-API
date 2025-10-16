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
            return await _marketContext.ItemCategories.ToListAsync();
        }

        [HttpGet]
        [Route("getSubcategories")]
        public async Task<IEnumerable<ItemSubcategory>> GetItemSubcategories(int categoryId)
        {
            return await _marketContext.ItemSubcategories.Where(s => s.ItemCategoryId == categoryId).ToListAsync();
        }

        [HttpGet]
        [Route("itemsInSubcategory")]
        public async Task<IEnumerable<Item>> GetItemsInSubcategory(int subcategoryId)
        {
            return await _marketContext.Items.Where(s => s.ItemSubcategoryId == subcategoryId).ToListAsync();
        }

        [HttpGet]
        [Route("item")]
        public async Task<Item> GetItemById(int itemId)
        {
            return await _marketContext.Items.FirstOrDefaultAsync(item => item.Id == itemId) ?? new Item();
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
