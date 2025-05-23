namespace GreenMarket.Domain.Entities
{
    public class Order :BaseEntity<int>
    {
        public decimal TotalAmount { get; set; }
        public string PaymentMethod {  get; set; }
        public string ShippingAddress { get; set; }
        public string CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
