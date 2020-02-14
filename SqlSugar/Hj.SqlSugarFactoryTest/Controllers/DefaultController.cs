using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.SqlSugarFactory;
using Hj.SqlSugarFactory.Lib;
using Hj.SqlSugarFactoryTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlSugar;

namespace Hj.SqlSugarFactoryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public MySqlSugarClient _db;
        public SqlSugarClient db;
        public DefaultController(ISqlSugarFactory sqlSugarFactory)
        {
            _db = (MySqlSugarClient)sqlSugarFactory.CreateClient("LogsConnection");//Database=DGCN.HXCloud.ID4  Localhost LogsConnection
             db = sqlSugarFactory.CreateClient("LogsConnection");

            _db.AopDataLog(db, _db);
            //_db.Aop.OnDiffLogEvent = it =>
            //{
            //    var editBeforeData = it.BeforeData;
            //    var editAfterData = it.AfterData;
            //    var sql = it.Sql;
            //    var parameter = it.Parameters;
            //    var data = it.BusinessData;//表名
            //    var time = it.Time;
            //    var diffType = it.DiffType;//枚举值 insert 、update 和 delete 用来作业务区分

            //    //你可以在这里面写日志方法
            //    var oldValueJson = "";
            //    if (editBeforeData != null&&editBeforeData.Count!=0)
            //    {
            //        oldValueJson = JsonConvert.SerializeObject(editBeforeData[0].Columns);
            //    }

            //    var newValueJson = "" ;
            //    if (editAfterData != null && editAfterData.Count != 0)
            //    {
            //       newValueJson= JsonConvert.SerializeObject(editAfterData[0].Columns);
            //    }
            //    var model = new DataLog()
            //    {
            //        ID = Guid.NewGuid(),
            //        KeyValue = data.ToString(),
            //        OldValue = oldValueJson != "" ? oldValueJson : null,
            //        NewValue = newValueJson != "" ? newValueJson : null,
            //        OperateType = diffType.ToString(),
            //        UserName = "test",
            //        OperateTime = DateTime.Now.ToString()
            //    };
            //    db.Insertable(model).ExecuteCommand();
            //};
        }
        [HttpGet("Get")]
        public string Get()
        {
            //进行测试
            var _apiLog = new Models.ApiLog
            {
                ClientIP = "111111",
                ResponseTime = 12,
                AccessToken = "aaa",
                AccessTime = DateTime.Now.AddMilliseconds(-12),
                AccessApiUrl = "aaa",
                AccessAction = "aaa",
                AccessParameterGet = "",
                AccessParameterPost = "",
                HttpStatus = 200
            };
            _db.Insertable(_apiLog).ExecuteCommand();
            return "string";
        }
        [HttpGet("GetApi")]
        public string GetApi()
        {
            //进行测试
            var _apiLog = new Models.ApiLog
            {
                ClientIP = "111111",
                ResponseTime = 12,
                AccessToken = "aaa",
                AccessTime = DateTime.Now.AddMilliseconds(-12),
                AccessApiUrl = "aaa",
                AccessAction = "aaa",
                AccessParameterGet = "",
                AccessParameterPost = "",
                HttpStatus = 200
            };
            _db.Insertable(_apiLog).ExecuteCommand();

            _apiLog.ClientIP = "33333";
            var list= new List<string>() { "ClientIP" };
            _db.Updateable(_apiLog).Where(x => x.ALgID == 76912).UpdateColumns(list.ToArray()).ExecuteCommand();


           _db.Deleteable<ApiLog>(x => x.ALgID == 76917).ExecuteCommand();
            return "string";
        }
    }
}