using GreenMarket.Domain.Entities;
using GreenMarket.Domain.Interfaces.Entities;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class CartItemRepository : Repository<CartItem, int>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
        {
        }
    }
}
