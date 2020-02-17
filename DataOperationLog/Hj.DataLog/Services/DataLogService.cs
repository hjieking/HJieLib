using Hj.DataLog.IServices;
using Hj.SqlSugarFactory;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hj.DataLog.Services
{
    public class DataLogService: IDataLogService
    {
        public SqlSugarClient _db { get; set; }
        public DataLogService(ISqlSugarFactory sqlSugarFactory)
        {
            _db = sqlSugarFactory.CreateClient("LogsConnection");
        }

        public int Add(Models.DataLog dataLog)
        {
            return _db.Insertable(dataLog).ExecuteCommand();
        }
    }
}
