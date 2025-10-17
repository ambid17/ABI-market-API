namespace abi_market.Models
{
    public class ItemPrice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
