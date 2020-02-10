using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SqlSugar;
using System;

namespace Hj.SqlSugarFactory
{
    public static class SqlSugarFactoryCollectionExtentions
    {
        public static ISqlSugarFactoryBuilder AddSqlSugar(this IServiceCollection services,
            string name, Action<ConnectionConfig> configureClient)
        {
            if (configureClient == null)
            {
                throw new ArgumentNullException(nameof(configureClient));
            }

            services.AddSingleton<DefaultSqlSugarFactory>();
            services.TryAddSingleton<ISqlSugarFactory>(serviceProvider => serviceProvider.GetRequiredService<DefaultSqlSugarFactory>());

            var builder = new DefaultSqlSugarFactoryBuilder(services,name);
            builder.ConfigureSqlSugar(configureClient);
            return builder;
        }

    }
}
