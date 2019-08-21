using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using XH.Core.ComHelper.ComHelper;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using XH.Core.ComHelper.NoSQLHelper;
using XH.Core.ComHelper.Filter;
using XH.Core.IBLL.IResponse;
using XH.Core.DAL.Login;

namespace XH.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            try
            {
                Configuration = configuration;
                new AppSetingHelper().Initial(); 
            }
            catch (Exception)
            {
                throw new Exception("初始化错误，请联系管理员");
            }
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                //注册全局过滤器
                services.AddMvc(options => { options.Filters.Add(new ExpetionFilter());});

                services.AddTransient<IXHUser, XHUserDAL>();

                #region ef core 初始化
                //services.Configure<CookiePolicyOptions>(options =>
                //{
                //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //    options.CheckConsentNeeded = context => true;
                //    options.MinimumSameSitePolicy = SameSiteMode.None;
                //});
                //var connection = @"Server=.;Database=XHBase;Trusted_Connection=True;ConnectRetryCount=0";
                //services.AddDbContext<XHBaseContext>(options => options.UseSqlServer(connection));
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLogFile("XH.Core.Api-ConfigureServices", ex);
            }
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

   }
}
