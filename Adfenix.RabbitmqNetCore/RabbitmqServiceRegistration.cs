using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AdFenix.RabbitmqNetCore;


namespace AdFenix.RabbitmqNetCore
{
    public class RabbitmqServiceRegistration
    {
        public static void Register(IServiceCollection services, out IServiceCollection serviceCollection)
        {
            services.AddTransient<IRabbitmqConnect, RabbitmqConnect>();
            services.AddTransient<IRabbitmqProducerService, RabbitmqProducerService>();
            services.AddTransient<IRabbitmqConsumerService, RabbitmqConsumerService>();

            serviceCollection = services;

        }

    }
}
