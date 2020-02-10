using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hj.SqlSugarFactory
{
    public static class SqlSugarFactoryBuilderExtensions
    {
        public static ISqlSugarFactoryBuilder ConfigureSqlSugar(this ISqlSugarFactoryBuilder builder,
            Action<ConnectionConfig> configureClient)
        {
            builder.Services.Configure<SqlSugarFactoryOptions>(builder.Name,
                options => options.SqlSugarActions.Add(configureClient));
            return builder;
        }
    }
}
