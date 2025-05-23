using GreenMarket.Domain.Entities;
using GreenMarket.Domain.Interfaces.Entities;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart, int>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
        {
        }
    }
}
