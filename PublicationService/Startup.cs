using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFenix.RabbitmqNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PublicationService
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
            services.AddMvc();
           
            RegisterRabbitmqServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();
        }

        public void RegisterRabbitmqServices(IServiceCollection services)
        {
            services.Configure<RabbitmqOptions>(Configuration.GetSection("Rabbitmq"));
            RabbitmqServiceRegistration.Register(services,out services);
        }
    }
}
