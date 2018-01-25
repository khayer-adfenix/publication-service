using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading;
using AdFenix.InfrastructureNetCore;
using AdFenix.RabbitmqNetCore;
using ConsumerService.Handlers;
using dFenix.InfrastructureNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<IRabbitmqConsumerRunner>().Run();

            //RegisterDependency();
            Console.WriteLine("Ress any key to exit");
            Console.Read();
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRabbitmqConsumerRunner, RabbitmqConsumerRunner>();

            //Todo: Need aufac like generic type registration
            serviceCollection
                .AddTransient<IActionCommandHandler<AddPublicationOwnerCommand>, AddPublicationOwnerCommandHandler>();


            RabbitmqServiceRegistration.Register(serviceCollection,out serviceCollection);
            InfrastructureServiceRegistration.Register(serviceCollection, out serviceCollection);
        }
    }
}
