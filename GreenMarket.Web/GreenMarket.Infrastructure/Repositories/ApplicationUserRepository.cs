using GreenMarket.Domain.Interfaces;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GreenMarket.Domain.Entities;
using GreenMarket.Domain.Interfaces.Entities;

namespace GreenMarket.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        protected DbSet<ApplicationUser> DbSet => _dbContext.Set<ApplicationUser>();

        public IUnitOfWork UnitOfWork => _dbContext;

        public ApplicationUserRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddOrUpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                await AddAsync(entity, cancellationToken);
            }
            else
            {
                await UpdateAsync(entity, cancellationToken);
            }
        }

        public async Task AddAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedTime = _dateTimeProvider.Now;
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedTime = _dateTimeProvider.Now;
            return Task.CompletedTask;
        }

        public void Delete(ApplicationUser entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<ApplicationUser> GetQueryableSet()
        {
            return DbSet.AsQueryable();
        }

        public async Task<ApplicationUser?> FirstOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ApplicationUser?> SingleOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ApplicationUser>> ToListAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.ToListAsync(cancellationToken);
        }

        public void SetRowVersion(ApplicationUser entity, byte[] version)
        {
            _dbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
        }

        public bool IsDbUpdateConcurrencyException(Exception ex)
        {
            return ex is DbUpdateConcurrencyException;
        }
    }

}
