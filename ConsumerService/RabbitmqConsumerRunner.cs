using System;
using System.Collections.Generic;
using System.Text;
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
            this.rabbitmqConsumerService.SetQueue(RabbitmqConfig.ExchangeBasicEvent,
                RabbitmqExchangeType.Direct,
                RabbitmqConfig.QueueBasicEvent,
                RabbitmqConfig.RoutingKeyBasicEventAddPublisher);

            this.rabbitmqConsumerService.ReceiveMessages(RabbitmqConfig.QueueBasicEvent);
            
            Console.WriteLine($"Listening {RabbitmqConfig.QueueBasicEvent}");
        }
    }
}
