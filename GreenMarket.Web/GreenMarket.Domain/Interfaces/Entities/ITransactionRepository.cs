using GreenMarket.Domain.Entities;

namespace GreenMarket.Domain.Interfaces.Entities
{
    public interface ITransactionRepository : IRepository<Transaction, int>
    {
    }
}
