using GreenMarket.Domain.Entities;

namespace GreenMarket.Domain.Interfaces.Entities
{
    public interface IApplicationUserRepository: IConcurrencyHandler<ApplicationUser>
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<ApplicationUser> GetQueryableSet();

        Task<ApplicationUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task AddOrUpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task AddAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        void Delete(ApplicationUser entity);

        Task<ApplicationUser?> FirstOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);

        Task<ApplicationUser?> SingleOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);

        Task<List<ApplicationUser>> ToListAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);
    }
}
