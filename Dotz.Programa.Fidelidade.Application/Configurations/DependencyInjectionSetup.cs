using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories;
using Dotz.Programa.Fidelidade.Infrastructure.Uow;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotz.Programa.Fidelidade.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUserRepository, UserAccountRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPointsTransactionRepository, PointsTransactionRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IExchangeRepository, ExchangeRepository>();
            services.AddTransient<IExchangeItemRepository, ExchangeItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }
    }
}
