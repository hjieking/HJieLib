using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp
{
    /// <summary>
    /// IApplicationBuilder接口
    /// </summary>
    public interface IApplicationBuilder
    {
        /// <summary>
        /// 注册中间件方法
        /// </summary>
        /// <param name="middleware"></param>
        /// <returns></returns>
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        /// <summary>
        /// 将注册中间件构建成一个RequestDelegate对象。
        /// </summary>
        /// <returns></returns>
        RequestDelegate Build();
    }
    /// <summary>
    /// 1、将注册中间件构建成一个RequestDelegate对象。
    /// 2、注册中间件。
    /// </summary>
    public class ApplicationBuilder : IApplicationBuilder
    {
        /// <summary>
        /// 保存中间件   
        /// </summary>
        private readonly List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        /// <summary>
        /// 将注册中间件构建成一个RequestDelegate对象。
        /// </summary>
        /// <returns></returns>
        public RequestDelegate Build()
        {
            _middlewares.Reverse();
            return httpContext =>
            {
                RequestDelegate next = _ => { _.Response.StatusCode = 404; return Task.CompletedTask; };
                foreach (var middleware in _middlewares)
                {
                    next = middleware(next);
                }
                return next(httpContext);
            };
        }
        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="middleware"></param>
        /// <returns></returns>
        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
