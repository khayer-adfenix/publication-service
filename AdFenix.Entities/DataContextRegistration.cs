using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AdFenix.Entities.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdFenix.Entities
{
    public class DataContextRegistration
    {
        public static void Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdFenixDbConext>(o => o.UseNpgsql(connectionString));
        }
    }
}
