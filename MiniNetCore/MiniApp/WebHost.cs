using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp
{
    public interface IWebHost
    {
        Task StartAsync();
    }
    /// <summary>
    /// 1、WebHost主要是构建管道
    /// 2、管道=server+中间件（HttpHandler）
    /// </summary>
    public class WebHost : IWebHost
    {
        private readonly IServer _server;
        private readonly RequestDelegate _handler;
        public WebHost(IServer server, RequestDelegate handler)
        {
            _server = server;
            _handler = handler;
        }
        public Task StartAsync() => _server.StartAsync(_handler);
    }
}
