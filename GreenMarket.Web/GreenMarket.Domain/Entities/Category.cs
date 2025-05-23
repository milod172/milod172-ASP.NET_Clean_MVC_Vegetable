namespace GreenMarket.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category? ParentCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
