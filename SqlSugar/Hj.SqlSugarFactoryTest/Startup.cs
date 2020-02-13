using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.SqlSugarFactory;
using Hj.SqlSugarFactoryTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hj.SqlSugarFactoryTest
{
    public class Startup
    {
        public IConfiguration Cfg { get; }

        public Startup(IConfiguration configuration)
        {
            Cfg = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("json.json").Build();


            var connectionString = Cfg.GetConnectionString("Localhost") ?? "";

            services.AddSqlSugar("Localhost", cfg=>
            {
                cfg.ConnectionString = connectionString;
                cfg.DbType = SqlSugar.DbType.SqlServer;         //必填, 数据库类型
                cfg.IsAutoCloseConnection = true;       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                cfg.InitKeyType = SqlSugar.InitKeyType.SystemTable;
            });
            //services.AddSqlSugar("LogsConnection", cfg =>
            //{
            //    cfg.ConnectionString = ConfigurationExtensions.GetConnectionString(Cfg, "LogsConnection") ?? "";//必填, 数据库连接字符串
            //    cfg.DbType = SqlSugar.DbType.SqlServer;         //必填, 数据库类型
            //    cfg.IsAutoCloseConnection = true;       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
            //    cfg.InitKeyType = SqlSugar.InitKeyType.SystemTable;    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
            //});

            //services.AddSingleton<IMessageService, EmailService>();
            services.AddMessage(option=> {
                option.UseSms();
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
