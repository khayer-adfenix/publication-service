using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

            this.rabbitmqConsumerService.SetQueue(RabbitmqConfig.ExchangeBasicEvent,
                RabbitmqExchangeType.Direct,
                RabbitmqConfig.QueueBasicEvent,
                RabbitmqConfig.RoutingKeyBasicEventAddPublisher);

            this.rabbitmqConsumerService.ReceiveMessages(RabbitmqConfig.QueueBasicEvent);
            
            Console.WriteLine($"Listening {RabbitmqConfig.QueueBasicEvent}");
        }
    }
}
