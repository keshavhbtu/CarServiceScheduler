using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceScheduler.DataLayer;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.ServiceLayer;
using CarServiceScheduler.ServiceLayer.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarServiceScheduler
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); ;
            });
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddControllers();

            services.AddSingleton<IAppointmentBusinessService, AppointmentBusinessService>();
            services.AddSingleton<IAppointmentDataService, AppointmentDataService>();
            services.AddSingleton<ICustomerBusinessService, CustomerBusinessService>();
            services.AddSingleton<ICustomerDataService, CustomerDataService>();
            services.AddSingleton<IOperatorBusinessService, OperatorBusinessService>();
            services.AddSingleton<IOperatorDataService, OperatorDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
