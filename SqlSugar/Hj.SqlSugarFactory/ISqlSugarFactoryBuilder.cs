﻿using Microsoft.Extensions.DependencyInjection;

namespace Hj.SqlSugarFactory
{
    public interface ISqlSugarFactoryBuilder
    {
        /// <summary>
        /// Gets the name of the client configured by this builder.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the application service collection.
        /// </summary>
        IServiceCollection Services { get; }
    }
}