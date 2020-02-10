using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hj.SqlSugarFactory
{
    public class SqlSugarFactoryOptions
    {
        public IList<Action<ConnectionConfig>> SqlSugarActions { get; } = new List<Action<ConnectionConfig>>();
    }
}