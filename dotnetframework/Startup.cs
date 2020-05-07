using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetframework.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace dotnetframework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddAuthentication();
            services.AddRouting();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ȫ�ֻ�ȡHttpContext
            HttpContextMiddleware.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            ///���jwt��֤
            app.UseAuthentication();
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ʹ�þ�̬��Դ
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
