using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.DataLog.IServices;
using Hj.DataLog.Services;
using Hj.SqlSugarFactory;
using Hj.SqlSugarFactory.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace Hj.DataLog.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public MySqlSugarClient _db;
        public SqlSugarClient db;
        public IDataLogService _logService;
        public DefaultController(ISqlSugarFactory sqlSugarFactory, IDataLogService logService)
        {
            _db = (MySqlSugarClient)sqlSugarFactory.CreateClient("LogsConnection");//Database=DGCN.HXCloud.ID4  Localhost LogsConnection

            _logService = logService;
            //1、解决方案：重写SqlSugarClient客户端   （1）使用方便（2）要在注入的时候修改
            //2、解决方案：扩展SqlSugarClient客户端   （1）注入不需要修改（2）但所有方法使用的时候需要执行EnableDiffLogEvent方法
            //3、解决方案：使用OnLogExecuted          （1）方法执行前后的数据获取不到即使修改也很难
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
           int nus=  _db.Insertable(_apiLog).ExecuteCommand();
            _logService.Add(new DataLog.Models.DataLog() { DataID="abc", DataJson="aaaa"});

            _apiLog.ClientIP = "33333";
            var list = new List<string>() { "ClientIP" };
            //_db.Updateable(_apiLog).Where(x => x.ALgID >= 77001).UpdateColumns(list.ToArray()).ExecuteCommand();


            //var dt = _db.Ado.ExecuteCommand("update ApiLog set ClientIP=@ClientIP where ALgID>=76994",
            //    new List<SugarParameter>(){
            //      new SugarParameter("@ClientIP","aaaa") //参数
            //    });

            //var dt = _db.Ado.ExecuteCommand("delete ApiLog where   ALgID >=@ALgID", new  List<SugarParameter>(){ 
            //   new SugarParameter("@ALgID", "76994")
            //});

            //_db.Deleteable<ApiLog>(x => x.ALgID >= 76997).ExecuteCommand();
            return "string";
        }
    }
}