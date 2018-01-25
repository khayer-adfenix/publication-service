using System;
using System.Collections.Generic;
using System.Text;

namespace AdFenix.RabbitmqNetCore
{
    public class RabbitmqNetCoreAppConfig
    {
        public string Rabbitmq_HostName { get; set; }
        public string Rabbitmq_UserName { get; set; }
        public string Rabbitmq_Password { get; set; }
        public string Rabbitmq_VirtualHost { get; set; }
    }
}
