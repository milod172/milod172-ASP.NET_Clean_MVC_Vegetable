using GreenMarket.Domain.Interfaces;
using GreenMarket.Domain.Interfaces.Entities;
using GreenMarket.Infrastructure.Persistence.DateTimes;
using GreenMarket.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GreenMarket.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            }))
                    .AddDbContextFactory<AppDbContext>((Action<DbContextOptionsBuilder>)null, ServiceLifetime.Scoped)
                    .AddRepositories();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));            
            services.AddScoped(typeof(IUnitOfWork), services =>
            {
                return services.GetRequiredService<AppDbContext>();
            });    
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();

            return services;
        }
    }
}
