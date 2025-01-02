using Microsoft.Extensions.Options;
using SatrackBankSystem.Infrastructure.Factories;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Repositories;
using SatrackBankSystem.Infrastructure.Repositories.Base;
using SatrackBankSystem.Infrastructure.Services;
using SatrackBankSystem.Infrastructure.Settings;

namespace SatrackBankSystem.Api.Extensions
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCoreExtension(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration
            services.Configure<InfrastructureSettings>(configuration);

            //ConnectionString
            services.AddSingleton<string>(provider =>
                provider.GetRequiredService<IOptions<InfrastructureSettings>>().Value.SqlSettings.ConnectionString
            );

            ////Repositories
            services.AddTransient<IBusinessClientRepository, BusinessClientRepository>();
            services.AddTransient<IIndividualClientRepository, IndividualClientRepository>();
            services.AddTransient<ISavingsAccountRepository, SavingsAccountRepository>();
            services.AddTransient<ICurrentAccountRepository, CurrentAccountRepository>();
            services.AddTransient<ICDTAccountRepository, CDTAccountRepository>();
            services.AddTransient<IClientQueryRepository, ClientQueryRepository>();
            services.AddTransient<IFinancialProductsQueryRepository, FinancialProductsQueryRepository>();
            services.AddTransient<ISqlServerBase<dynamic>>(provider =>
                new SqlServerBase<dynamic>(provider.GetRequiredService<string>())
            );

            //Services
            services.AddTransient<IValidationService, ValidationService>();

            //Factories
            services.AddScoped<IClientFactory, ClientFactory>();
            services.AddScoped<IClientRepositoryFactory, ClientRepositoryFactory>();
            services.AddScoped<IFinancialProductRepositoryFactory, FinancialProductRepositoryFactory>();

            return services;
        }
    }
}
