using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.SqlSugarFactoryTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hj.SqlSugarFactoryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesController : ControllerBase
    {
        public IMessageService _messageService;
        public MesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public string Get()
        {
            return _messageService.Send();
        }
    }
}