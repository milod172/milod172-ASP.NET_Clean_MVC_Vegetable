namespace GreenMarket.Domain.Entities
{
    public class CartItem : BaseEntity<int>
    {
        public int CartId { get; set; } 
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
