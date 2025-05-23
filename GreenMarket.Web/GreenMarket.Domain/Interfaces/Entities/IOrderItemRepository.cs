using GreenMarket.Domain.Entities;

namespace GreenMarket.Domain.Interfaces.Entities
{
    public interface IOrderItemRepository : IRepository<OrderItem, int>
    {
    }
}
