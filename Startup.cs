using BlazorApp1.Data;
using BlazorApp1.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped(typeof(PageStorageService<>), typeof(PageStorageService<>));
         

            //services.AddAllGenericTypes(typeof(IStoredPage<Counter>), new[] { typeof(PageStorageService<>).GetTypeInfo().Assembly });
            
           // System.Reflection.Assembly.GetExecutingAssembly()
           //.GetTypes()
           //.Where(item => item.GetInterfaces()
           //.Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IStoredPage<>)) && !item.IsAbstract && !item.IsInterface)
           //.ToList()
           //.ForEach(assignedTypes =>
           //{
           //    var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IStoredPage<>));
           //    services.AddScoped(serviceType, assignedTypes);
           //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
