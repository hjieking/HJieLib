using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.SqlSugarFactory;
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
            _db = sqlSugarFactory.CreateClient("LogsConnection");//Database=DGCN.HXCloud.ID4
        }
        [HttpGet]
        public string Get()
        {
            //var departQueryable = _db.Queryable<Department>().Where(x => x.IsDelete == false).ToList();
            return "string";
        }
    }
}