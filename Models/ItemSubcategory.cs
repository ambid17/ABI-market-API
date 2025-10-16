namespace abi_market.Models
{
    public class ItemSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ItemCategoryId { get; set; }
    }
}
