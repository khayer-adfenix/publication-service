using System.Collections.Generic;
using System;

namespace AdFenix.RabbitmqNetCore
{
    public class RabbitmqConfig
    {
        //public const string RabbitmqUserName = "hxojonoh";
        //public const string RabbitmqPassword = "deWjEiFHYQvBVr9LnEUXxZ6uUa8UBdFK";
        //public const string RabbitmqHost = "termite.rmq.cloudamqp.com";
        //public const string RabbitmqVirtualHost = "hxojonoh";

        public const string RabbitmqUserName = "guest";
        public const string RabbitmqPassword = "guest";
        public const string RabbitmqHost = "rabbitmq";
        public const string RabbitmqVirtualHost = "/";
        public const int RabbitmqPort = 5672;

        public const string QueueBasicEvent = "event.addpublisher";
        public const string ExchangeBasicEvent = "event.exchange";

        public const string DeadLetterExchange = "dlx.common";
        public const string DeadLetterAllQueue = "dlx.queue.all";

        public const string RoutingKeyBasicEventAddPublisher = "event.addpublisher";

    }
}
