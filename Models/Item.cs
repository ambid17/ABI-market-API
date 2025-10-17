namespace abi_market.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ItemCategoryId { get; set; }
        public ItemCategory? ItemCategory { get; set; } = null!;
        public int ItemSubcategoryId { get; set; }
        public ItemSubcategory? ItemSubcategory { get; set; } = null!;
        public ICollection<ItemPrice>? ItemPrices { get; set; } = new List<ItemPrice>();
    }
}
