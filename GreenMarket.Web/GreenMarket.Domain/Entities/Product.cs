namespace GreenMarket.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string ProductName { get; set; }
        public string? Details { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
