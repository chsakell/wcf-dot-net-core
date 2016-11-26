using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ServiceModel;

namespace Core.App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Connected Services
            services.AddSingleton(typeof(Connected.Service.BlogService.IBlogService),
                new Connected.Service.BlogService.BlogServiceClient(Connected.Service.BlogService.BlogServiceClient.EndpointConfiguration.BasicHttpBinding_IBlogService,
                "http://localhost:8090/BlogHttpService"));

            services.AddSingleton(typeof(Connected.Service.ArticleService.IArticleService),
                new Connected.Service.ArticleService.ArticleServiceClient(Connected.Service.ArticleService.ArticleServiceClient.EndpointConfiguration.NetTcpBinding_IArticleService,
                "net.tcp://localhost:8080/ArticleNetTcpService"));

            // External Lib services
            var netTcpBinding = new NetTcpBinding();
            services.AddSingleton(typeof(External.Lib.IArticleService),
                new External.Lib.ArticleServiceClientExt(netTcpBinding, new EndpointAddress("net.tcp://localhost:8080/ArticleNetTcpService")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
