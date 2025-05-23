using GreenMarket.Domain.Interfaces.Entities;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Infrastructure.Repositories
{
    public class OrderItemRepository : Repository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
        {
        }
    }
}
