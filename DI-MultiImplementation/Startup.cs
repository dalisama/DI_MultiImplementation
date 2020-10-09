using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MultiImplementationLib;

namespace DI_MultiImplementation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Method 1

            services.AddTransient<IGetData, GetDataA>();
            services.AddTransient<IGetData, GetDataB>();
            services.AddTransient<IGetData, GetDataC>();

            #endregion


            #region Method 2
            services.AddTransient<GetDataA>();
            services.AddTransient<GetDataB>();
            services.AddTransient<GetDataC>();
            services.AddSingleton<Func<Keys, IGetData>>(serviceprovider => (key) =>
               {
                   switch (key)
                   {
                       case Keys.A: return serviceprovider.GetService<GetDataA>();
                       case Keys.B: return serviceprovider.GetService<GetDataB>();
                       case Keys.C: return serviceprovider.GetService<GetDataC>();
                       default:
                           throw new ArgumentException($"Can't find this key: {key}");
                   }
               });
            #endregion

            #region Method 3
            services.AddTransient<IGetDataA, GetDataAPrime>();
            services.AddTransient<IGetDataB, GetDataBPrime>();
            services.AddTransient<IGetDataC, GetDataCPrime>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
