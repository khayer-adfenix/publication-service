using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using dFenix.InfrastructureNetCore;

namespace AdFenix.InfrastructureNetCore
{
    public class InfrastructureServiceRegistration
    {
        public static void Register(IServiceCollection services, out IServiceCollection serviceCollection)
        {

            services.AddTransient<IActionCommandDispacher, ActionCommandDispacher>();
            serviceCollection = services;

        }
        
    }
}
