using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hj.DataLog.IServices;
using Hj.DataLog.Services;
using Hj.SqlSugarFactory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hj.DataLog.Test
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
            services.AddSqlSugar("LogsConnection", cfg =>
            {
                cfg.ConnectionString = ConfigurationExtensions.GetConnectionString(Cfg, "LogsConnection") ?? "";//����, ���ݿ������ַ���
                cfg.DbType = SqlSugar.DbType.SqlServer;         //����, ���ݿ�����
                cfg.IsAutoCloseConnection = true;       //Ĭ��false, ʱ��֪���ر����ݿ�����, ����Ϊtrue����ʹ��using����Close����
                cfg.InitKeyType = SqlSugar.InitKeyType.SystemTable;    //Ĭ��SystemTable, �ֶ���Ϣ��ȡ, �磺�������ǲ����������ǲ��Ǳ�ʶ�еȵ���Ϣ
            });
            services.AddSingleton<IDataLogService, DataLogService>();
            //services.AddSingleton<IDataLogService, DataLogService>(serviceProvider => serviceProvider.GetRequiredService<DataLogService>());
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

            //app.UseRouting();

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
