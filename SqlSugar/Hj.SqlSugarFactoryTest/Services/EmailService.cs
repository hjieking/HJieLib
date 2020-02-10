using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.SqlSugarFactoryTest.Services
{
    public class EmailService : IMessageService
    {
        public string Send()
        {
            return "邮箱";
        }
    }
}
