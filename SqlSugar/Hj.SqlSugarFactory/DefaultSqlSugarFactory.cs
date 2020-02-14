using Hj.SqlSugarFactory.Lib;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hj.SqlSugarFactory
{
    public class DefaultSqlSugarFactory : ISqlSugarFactory
    {
        private readonly IOptionsMonitor<SqlSugarFactoryOptions> _optionsMonitor;
        public DefaultSqlSugarFactory(IOptionsMonitor<SqlSugarFactoryOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
        }
        public SqlSugarClient CreateClient(string name)
        {
            var client = new MySqlSugarClient(new ConnectionConfig { });

            var option = _optionsMonitor.Get(name).SqlSugarActions.FirstOrDefault();
            if (option != null)
            {
                option(client.CurrentConnectionConfig);
            }
            return client;
        }
    }
}
