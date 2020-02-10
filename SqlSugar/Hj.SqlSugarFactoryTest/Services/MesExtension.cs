using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.SqlSugarFactoryTest.Services
{
    public static class MesExtension
    {
        public static void AddMessage(this IServiceCollection services,
            Action<MessageServiceBuilder> action)
        {
            //services.AddSingleton<IMessageService, EmailService>();

            var builder = new MessageServiceBuilder(services);
            action(builder);//委托方法执行
        }
    }
}
