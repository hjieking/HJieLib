using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.SqlSugarFactoryTest.Services
{
    public class MessageServiceBuilder
    {
        public IServiceCollection servicesCollection { get; set; }
        public MessageServiceBuilder(IServiceCollection services)
        {
            servicesCollection = services;
        }

        public void UseEmail()
        {
            servicesCollection.AddSingleton<IMessageService, EmailService>();
        }
        public void UseSms()
        {
            servicesCollection.AddSingleton<IMessageService, SmsService>();
        }
    }
}
