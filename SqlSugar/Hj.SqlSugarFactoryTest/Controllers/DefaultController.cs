using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.SqlSugarFactory;
using Hj.SqlSugarFactoryTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace Hj.SqlSugarFactoryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public SqlSugarClient _db;
        public DefaultController(ISqlSugarFactory sqlSugarFactory)
        {
            _db = sqlSugarFactory.CreateClient("Localhost");//Database=DGCN.HXCloud.ID4
            _db.Aop.OnDiffLogEvent = it =>
            {
                var editBeforeData = it.BeforeData;
                var editAfterData = it.AfterData;
                var sql = it.Sql;
                var parameter = it.Parameters;
                var data = it.BusinessData;
                var time = it.Time;
                var diffType = it.DiffType;//枚举值 insert 、update 和 delete 用来作业务区分

                //你可以在这里面写日志方法
            };
        }
        [HttpGet]
        public string Get()
        {
            var t12 = _db.Insertable<Test>(new { Id=2, Name = "a" }).EnableDiffLogEvent(new { title = "add test" }).ExecuteCommand();
            return "string";
        }
    }
}