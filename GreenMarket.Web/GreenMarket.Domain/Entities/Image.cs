namespace GreenMarket.Domain.Entities
{
    public class Image : BaseEntity<int>
    {
        public string ImageUrl { get; set; }
        public bool isPrimary { get; set; }
        public int ObjectId { get; set; }
    }
}
