using System;
using System.Threading.Tasks;

namespace MiniApp
{
    class Program
    {
        public static async Task Main()
        {
            await new WebHostBuilder()
                .UseHttpListener()
                .Configure(app => app
                    .Use(FooMiddleware)
                    .Use(BarMiddleware)
                    .Use(BazMiddleware))
                .Build()
                .StartAsync();
        }
        /// <summary>
        /// 当前的输出是后续的输入
        /// 当前中间件完成了自身的任务之后，需要请求分发给后续的中间件进行处理。
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public static RequestDelegate FooMiddleware(RequestDelegate next)
=> async context => {
    await context.Response.WriteAsync("Foo=>");
    await next(context);
};

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        => async context => {
            await context.Response.WriteAsync("Bar=>");
            await next(context);
        };

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        => context => context.Response.WriteAsync("Baz");
    }
}
