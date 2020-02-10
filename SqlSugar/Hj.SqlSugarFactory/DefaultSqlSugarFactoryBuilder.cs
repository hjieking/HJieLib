using Microsoft.Extensions.DependencyInjection;

namespace Hj.SqlSugarFactory
{
    internal class DefaultSqlSugarFactoryBuilder: ISqlSugarFactoryBuilder
    {
        public IServiceCollection Services { get; }
        public string Name { get; set; }

        public DefaultSqlSugarFactoryBuilder(IServiceCollection services, string name)
        {
            this.Services = services;
            this.Name = name;
        }
    }
}