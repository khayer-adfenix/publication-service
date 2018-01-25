using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdFenix.InfrastructureNetCore;
using AdFenix.RabbitmqNetCore;
using ConsumerService.DatabaseContext;
using ConsumerService.Handlers;
using dFenix.InfrastructureNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsumerService
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

            RegisterCustomServices(services);

            var connectionString = Configuration["connectionStrings:AdfenixConnectionString"];

            //services.AddEntityFrameworkNpgsql()
            //    .AddDbContext<AdFenixDbConext>(options =>
            //        options.UseNpgsql(connectionString));

            services.AddDbContext<AdFenixDbConext>(o => o.UseNpgsql(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            try
            {
                RunRabbitConsumer(serviceProvider);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void RegisterCustomServices(IServiceCollection service)
        {
            InfrastructureServiceRegistration.Register(service, out service);
            RabbitmqServiceRegistration.Register(service, out service);

            service
                .AddTransient<IActionCommandHandler<AddPublicationOwnerCommand>, AddPublicationOwnerCommandHandler>();

        }

        public void RunRabbitConsumer(IServiceProvider serviceProvider)
        {
            Console.WriteLine($"Starting Rabbit Reciver..");
            Thread.Sleep(15000);

            var rabbitmqConsumerService = serviceProvider.GetService<IRabbitmqConsumerService>();
            Retry.Do(() =>
            {
                rabbitmqConsumerService.SetQueue(RabbitmqConfig.ExchangeBasicEvent,
                    RabbitmqExchangeType.Direct,
                    RabbitmqConfig.QueueBasicEvent,
                    RabbitmqConfig.RoutingKeyBasicEventAddPublisher);

                Task.Run(() => rabbitmqConsumerService.ReceiveMessages(RabbitmqConfig.QueueBasicEvent));
            }, TimeSpan.FromSeconds(5), 3);

            Console.WriteLine($"Listening {RabbitmqConfig.QueueBasicEvent}");
        }
    }
}
