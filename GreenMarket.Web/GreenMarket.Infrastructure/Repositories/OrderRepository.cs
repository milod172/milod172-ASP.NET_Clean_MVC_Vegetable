using GreenMarket.Domain.Interfaces.Entities;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
        {
        }
    }
}
