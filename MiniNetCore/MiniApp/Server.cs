using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp
{
    public interface IServer
    {
        /// <summary>
        /// 我们通过定义在IServer接口的唯一方法StartAsync启动服务器，
        /// 作为参数的handler正是由所有注册中间件共同构建而成的RequestDelegate对象
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        Task StartAsync(RequestDelegate handler);
    }
}
