using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hj.SqlSugarFactory.Lib
{
    public static class SqlSugarClientExtentions
    {
        public static void DataLogAop(this SqlSugarClient sqlSugarClient, SqlSugarClient dbDataLog)
        {
            //var model = new DataLog();
            //sqlSugarClient.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            //{
            //    model.ID = Guid.NewGuid();

            //    var aa = sqlSugarClient.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));
            //    model.NewValue = aa;
            //    model.KeyValue = "";
            //    model.OperateType = "";
            //    model.OperateTime = DateTime.Now.ToString();
            //    dbDataLog.Insertable(model).ExecuteCommand();
            //};
            //sqlSugarClient.Aop.OnLogExecuting = (sql, pars) => //SQL执行前事件
            //{
            //    var aa = sqlSugarClient.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));
            //    model.OldValue = aa;

            //};
            sqlSugarClient.Aop.OnDiffLogEvent = it =>
            {
                var editBeforeData = it.BeforeData;
                var editAfterData = it.AfterData;
                var sql = it.Sql;
                var parameter = it.Parameters;
                var data = it.BusinessData;//表名
                var time = it.Time;
                var diffType = it.DiffType;//枚举值 insert 、update 和 delete 用来作业务区分

                //你可以在这里面写日志方法
                var oldValueJson = "";
                if (editBeforeData != null && editBeforeData.Count != 0)
                {
                    oldValueJson = JsonConvert.SerializeObject(editBeforeData[0].Columns);
                }

                var newValueJson = "";
                if (editAfterData != null && editAfterData.Count != 0)
                {
                    newValueJson = JsonConvert.SerializeObject(editAfterData[0].Columns);
                }
                var model = new DataLog()
                {
                    ID = Guid.NewGuid(),
                    //KeyValue = data.ToString(),
                    OldValue = oldValueJson != "" ? oldValueJson : null,
                    NewValue = newValueJson != "" ? newValueJson : null,
                    OperateType = diffType.ToString(),
                    UserName = "test",
                    OperateTime = DateTime.Now.ToString()
                };
                dbDataLog.Insertable(model).ExecuteCommand();
            };
        }
    }
}
