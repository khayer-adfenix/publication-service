using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdFenix.InfrastructureNetCore;
using AdFenix.RabbitmqNetCore;

namespace ConsumerService
{
    public interface IRabbitmqConsumerRunner
    {
        void Run();
    }
    public class RabbitmqConsumerRunner: IRabbitmqConsumerRunner
    {
        private IRabbitmqConsumerService rabbitmqConsumerService;

        public RabbitmqConsumerRunner(IRabbitmqConsumerService rabbitmqConsumerService)
        {
            this.rabbitmqConsumerService = rabbitmqConsumerService;


        }
        public void Run()
        {
            Console.WriteLine($"Starting Rabbit Reciver..");
            Thread.Sleep(5000);

            Retry.Do(() =>
            {
                this.rabbitmqConsumerService.SetQueue(RabbitmqConfig.ExchangeBasicEvent,
                    RabbitmqExchangeType.Direct,
                    RabbitmqConfig.QueueBasicEvent,
                    RabbitmqConfig.RoutingKeyBasicEventAddPublisher);

                Task.Run(() => this.rabbitmqConsumerService.ReceiveMessages(RabbitmqConfig.QueueBasicEvent));
            }, TimeSpan.FromSeconds(5), 3);
            
            Console.WriteLine($"Listening {RabbitmqConfig.QueueBasicEvent}");
        }
    }
}
