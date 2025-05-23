namespace GreenMarket.Domain.Entities
{
    public class Transaction : BaseEntity<int>
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string CustomerId { get; set; }
        public virtual ApplicationUser Customer {  get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
