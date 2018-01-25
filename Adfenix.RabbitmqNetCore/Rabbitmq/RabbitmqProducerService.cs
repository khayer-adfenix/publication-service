﻿using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;
using AdFenix.InfrastructureNetCore;

namespace AdFenix.RabbitmqNetCore
{
    public class RabbitmqProducerService: IRabbitmqProducerService
    {
        private IRabbitmqConnect rabbitmqConnect;
        private IModel Channel;
        //private ILogger logger;
        //private ISlackSimpleClient slackSimpleClient;
        private const string commandTypeName = "commandType";

        public RabbitmqProducerService(IRabbitmqConnect rabbitmqConnect)
        {
            this.rabbitmqConnect = rabbitmqConnect;
            //this.logger = logger;
            //this.slackSimpleClient = slackSimpleClient;
        }

        private void ClearConnection()
        {
            try
            {
                this.rabbitmqConnect.CloseConnection();
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex,ex.Message);
            }
        }
        public void CloseChannel()
        {
            try
            {
                this.Channel?.Close();
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex, "error in CloseChannel.");
            }
        }
        public void SetExchange(string exchangeName,string exchangeType)
        {
            try
            {
                this.Channel = this.rabbitmqConnect.SetExchange(exchangeName,exchangeType);
            }
            catch (Exception e)
            {
                var errorMsg = "Publisher SetExchange failed.";
                //this.logger.Error(e, errorMsg);
                //this.slackSimpleClient.PostException(SlackSetting.ERROR_EXCEPTION_WEB_HOOK,e, errorMsg);
            }
        }
        public void BasicPublish(string exchangeName,IQueueCommand command, string routingKey = "",bool isDoChannelClose=true)
        {
            try
            {
                var basicProperties = this.Channel.CreateBasicProperties();
                basicProperties.Headers = new Dictionary<string, object>
                {
                    {commandTypeName, command.GetType().AssemblyQualifiedName},
                    {"host", Environment.MachineName}
                };

                var message = JsonConvert.SerializeObject(command);
                var body = Encoding.UTF8.GetBytes(message);

                var address = new PublicationAddress(ExchangeType.Fanout, exchangeName, routingKey);

                //Retry.Do(() =>
                //{
                //    this.Channel.BasicPublish(address, basicProperties, body);
                //}, TimeSpan.FromSeconds(1));
                this.Channel.BasicPublish(address, basicProperties, body);
            }
            catch (Exception e)
            {
                var erroMsg = "Rabbitmq Message published failed.";
                //this.logger.Error(e, erroMsg);
                //this.slackSimpleClient.PostException(SlackSetting.ERROR_EXCEPTION_WEB_HOOK, e, erroMsg);
            }

            //this.logger.Info($"Publish to {exchangeName}");

            if (isDoChannelClose)
            {
                CloseChannel();
            }
        }
    }
}