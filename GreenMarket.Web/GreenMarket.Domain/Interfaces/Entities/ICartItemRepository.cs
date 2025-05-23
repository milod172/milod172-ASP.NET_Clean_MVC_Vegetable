using GreenMarket.Domain.Entities;

namespace GreenMarket.Domain.Interfaces.Entities
{
    public interface ICartItemRepository  : IRepository<CartItem, int>
    {
    }
}
