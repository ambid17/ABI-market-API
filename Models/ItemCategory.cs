namespace abi_market.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ItemSubcategory> ItemSubcategories { get; set; } = new List<ItemSubcategory>();
    }
}
